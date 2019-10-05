using System;
using System.Linq;
using System.Linq.Expressions;

namespace MORM.CrossCutting
{
    public static class ExpressionExtensions
    {
        public static IQueryable<TInstance> SetFiltroQueryable<TInstance>(
            this IQueryable<TInstance> queryable, object filtro, bool isKeyOnly = false)
        {
            var metadata = typeof(TInstance).GetMetadata();

            var campos = isKeyOnly ? metadata.Campos.Where(x => x.IsKey()) : metadata.Campos;
            Expression<Func<TInstance, bool>> expressionWhere = null;

            foreach (var campo in campos)
            {
                var valueObj = campo.Prop.GetValue(filtro);
                if (isKeyOnly || (!valueObj.IsValueNull()))
                {
                    var value = campo.Prop.GetValue(filtro);
                    var expression = GetEquality<TInstance>(value, new[] { campo.Prop.Name });
                    expressionWhere = expressionWhere == null 
                        ? expression
                        : expressionWhere.CombineAnd(expression)
                        ;
                }
            }

            if (expressionWhere != null)
                queryable = queryable.Where(expressionWhere);

            return queryable;
        }

        private static Expression<Func<TSource, bool>> GetEquality<TSource>(object value, params string[] properties)
        {
            ParameterExpression pe = Expression.Parameter(typeof(TSource), "source");

            Expression lastMember = pe;

            for (int i = 0; i < properties.Length; i++)
            {
                MemberExpression member = Expression.Property(lastMember, properties[i]);
                lastMember = member;
            }

            Expression valueExpression = Expression.Constant(value);
            Expression equalityExpression = Expression.Equal(lastMember, valueExpression);
            Expression<Func<TSource, bool>> lambda = Expression.Lambda<Func<TSource, bool>>(equalityExpression, pe);
            return lambda;
        }
    }
}