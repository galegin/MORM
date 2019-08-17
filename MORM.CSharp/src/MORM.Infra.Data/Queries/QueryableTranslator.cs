using MORM.Dominio.Interfaces;
using MORM.Infra.CrossCutting;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MORM.Infra.Data.Queries
{
    public class QueryableTranslator : ExpressionVisitor, IQueryableTranslator
    {
        public QueryableTranslator()
        {
        }

        private readonly IQueryableValue _queryableValue;

        public QueryableTranslator(IQueryableValue queryableValue)
        {
            _queryableValue = queryableValue ?? throw new ArgumentNullException(nameof(queryableValue));
        }

        private StringBuilder sb;

        public int? Skip { get; private set; }
        public int? Take { get; private set; }
        public string OrderBy { get; private set; }
        public string WhereClause { get; private set; }

        public string Translate(Expression expression)
        {
            this.sb = new StringBuilder();
            this.Visit(expression);
            WhereClause = this.sb.ToString();
            return WhereClause;
        }

        private static Expression StripQuotes(Expression e)
        {
            while (e.NodeType == ExpressionType.Quote)
            {
                e = ((UnaryExpression)e).Operand;
            }
            return e;
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.DeclaringType == typeof(Queryable) && m.Method.Name == "Where")
            {
                this.Visit(m.Arguments[0]);
                LambdaExpression lambda = (LambdaExpression)StripQuotes(m.Arguments[1]);
                this.Visit(lambda.Body);
                return m;
            }
            else if (m.Method.Name == "Take")
            {
                if (this.ParseTakeExpression(m))
                {
                    Expression nextExpression = m.Arguments[0];
                    return this.Visit(nextExpression);
                }
            }
            else if (m.Method.Name == "Skip")
            {
                if (this.ParseSkipExpression(m))
                {
                    Expression nextExpression = m.Arguments[0];
                    return this.Visit(nextExpression);
                }
            }
            else if (m.Method.Name == "OrderBy")
            {
                if (this.ParseOrderByExpression(m, "ASC"))
                {
                    Expression nextExpression = m.Arguments[0];
                    return this.Visit(nextExpression);
                }
            }
            else if (m.Method.Name == "OrderByDescending")
            {
                if (this.ParseOrderByExpression(m, "DESC"))
                {
                    Expression nextExpression = m.Arguments[0];
                    return this.Visit(nextExpression);
                }
            }

            throw new NotSupportedException(string.Format("The method '{0}' is not supported", m.Method.Name));
        }

        protected override Expression VisitUnary(UnaryExpression u)
        {
            switch (u.NodeType)
            {
                case ExpressionType.Not:
                    sb.Append(" NOT ");
                    this.Visit(u.Operand);
                    break;
                case ExpressionType.Convert:
                    this.Visit(u.Operand);
                    break;
                default:
                    throw new NotSupportedException(string.Format("The unary operator '{0}' is not supported", u.NodeType));
            }
            return u;
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            sb.Append("(");
            this.Visit(b.Left);

            switch (b.NodeType)
            {
                case ExpressionType.And:
                    sb.Append(" AND ");
                    break;

                case ExpressionType.AndAlso:
                    sb.Append(" AND ");
                    break;

                case ExpressionType.Or:
                    sb.Append(" OR ");
                    break;

                case ExpressionType.OrElse:
                    sb.Append(" OR ");
                    break;

                case ExpressionType.Equal:
                    if (IsNullConstant(b.Right))
                    {
                        sb.Append(" IS ");
                    }
                    else
                    {
                        sb.Append(" = ");
                    }
                    break;

                case ExpressionType.NotEqual:
                    if (IsNullConstant(b.Right))
                    {
                        sb.Append(" IS NOT ");
                    }
                    else
                    {
                        sb.Append(" <> ");
                    }
                    break;

                case ExpressionType.LessThan:
                    sb.Append(" < ");
                    break;

                case ExpressionType.LessThanOrEqual:
                    sb.Append(" <= ");
                    break;

                case ExpressionType.GreaterThan:
                    sb.Append(" > ");
                    break;

                case ExpressionType.GreaterThanOrEqual:
                    sb.Append(" >= ");
                    break;

                default:
                    throw new NotSupportedException(string.Format("The binary operator '{0}' is not supported", b.NodeType));

            }

            this.Visit(b.Right);
            sb.Append(")");
            return b;
        }

        private Expression VisitMemberAccess(MemberExpression m, string name)
        {
            if (m.Expression is ConstantExpression && m.Member is FieldInfo)
            {
                object container = ((ConstantExpression)m.Expression).Value;
                object value = ((FieldInfo)m.Member).GetValue(container);
                var valueObj = value.GetType().GetInstancePropOrField(value, name);
                return VisitConstantValue(m, valueObj);
            }
            else if (m.Expression is MemberExpression && m.Member is PropertyInfo)
            {
                object value = Expression.Lambda(m.Expression).Compile().DynamicInvoke();
                var valueMember = value.GetType().GetInstancePropOrField(value, m.Member.Name);
                var valueObj = valueMember.GetType().GetInstancePropOrField(valueMember, name);
                return VisitConstantValue(m, valueObj);
            }

            throw new NotSupportedException(string.Format("The member '{0}' is not supported", m.Member.Name));
        }

        protected Expression VisitConstantObject(ConstantExpression c, string campo)
        {
            object value = Expression.Lambda(c).Compile().DynamicInvoke();
            var valueObj = value.GetType().GetInstancePropOrField(value, campo);
            if (valueObj != null)
            {
                return VisitConstantValue(c, valueObj);
            }

            throw new NotSupportedException(string.Format("The field for '{0}' is not supported", campo));
        }

        protected Expression VisitConstantValue(Expression e, object value)
        {
            if (value is Enum)
            {
                sb.Append((int)value);
                return e;
            }

            if (_queryableValue != null)
            {
                var valueStr = _queryableValue.GetString(value);
                sb.Append(valueStr);
                return e;
            }

            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Boolean:
                    sb.Append(((bool)value) ? 1 : 0);
                    return e;

                case TypeCode.String:
                    sb.Append("'");
                    sb.Append(value);
                    sb.Append("'");
                    return e;

                case TypeCode.DateTime:
                    sb.Append("'");
                    sb.Append(value);
                    sb.Append("'");
                    return e;

                case TypeCode.Object:
                    throw new NotSupportedException(string.Format("The constant for '{0}' is not supported", value));

                default:
                    sb.Append(value);
                    return e;
            }
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            IQueryable q = c.Value as IQueryable;

            if (q == null && c.Value == null)
            {
                sb.Append("NULL");
            }
            else if (q == null)
            {
                return VisitConstantValue(c, c.Value);
            }

            return c;
        }

        protected override Expression VisitMember(MemberExpression m)
        {
            if (m.Expression != null && m.Expression.NodeType == ExpressionType.Parameter)
            {
                sb.Append(m.Member.Name);
                return m;
            }
            else if (m.Expression != null && m.Expression.NodeType == ExpressionType.Constant)
            {
                return VisitConstantObject(m.Expression as ConstantExpression, m.Member.Name);
            }
            else if (m.Expression != null && m.Expression.NodeType == ExpressionType.MemberAccess)
            {
                return VisitMemberAccess(m.Expression as MemberExpression, m.Member.Name);
            }

            throw new NotSupportedException(string.Format("The member '{0}' is not supported", m.Member.Name));
        }

        protected bool IsNullConstant(Expression exp)
        {
            return (exp.NodeType == ExpressionType.Constant && ((ConstantExpression)exp).Value == null);
        }

        private bool ParseOrderByExpression(MethodCallExpression expression, string order)
        {
            UnaryExpression unary = (UnaryExpression)expression.Arguments[1];
            LambdaExpression lambdaExpression = (LambdaExpression)unary.Operand;

            //lambdaExpression = (LambdaExpression)Evaluator.PartialEval(lambdaExpression);

            MemberExpression body = lambdaExpression.Body as MemberExpression;
            if (body != null)
            {
                if (string.IsNullOrEmpty(OrderBy))
                {
                    OrderBy = string.Format("{0} {1}", body.Member.Name, order);
                }
                else
                {
                    OrderBy = string.Format("{0}, {1} {2}", OrderBy, body.Member.Name, order);
                }

                return true;
            }

            return false;
        }

        private bool ParseTakeExpression(MethodCallExpression expression)
        {
            ConstantExpression sizeExpression = (ConstantExpression)expression.Arguments[1];

            int size;
            if (int.TryParse(sizeExpression.Value.ToString(), out size))
            {
                Take = size;
                return true;
            }

            return false;
        }

        private bool ParseSkipExpression(MethodCallExpression expression)
        {
            ConstantExpression sizeExpression = (ConstantExpression)expression.Arguments[1];

            int size;
            if (int.TryParse(sizeExpression.Value.ToString(), out size))
            {
                Skip = size;
                return true;
            }

            return false;
        }
    }
}