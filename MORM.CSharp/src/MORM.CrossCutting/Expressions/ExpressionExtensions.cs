using System;
using System.Linq;
using System.Linq.Expressions;

namespace MORM.CrossCutting
{
    public static class ExpressionExtensions
    {
        /*
        public static Expression<Func<TInput, object>> ToUntypedPropertyExpression<TInput, TOutput>(this Expression<Func<TInput, TOutput>> expression)
        {
            var memberName = ((MemberExpression)expression.Body).Member.Name;
            var param = Expression.Parameter(typeof(TInput));
            var field = Expression.Property(param, memberName);
            return Expression.Lambda<Func<TInput, object>>(field, param);
        }
        */

        /*
        public static IQueryable<TInstance> SetFiltroQueryable<TInstance>(this IQueryable<TInstance> queryable, object filtro)
        {
            foreach (var prop in typeof(TInstance).GetProperties())
            {
                var param = Expression.Parameter(prop.PropertyType);
                var field = Expression.Property(param, prop.Name);
                var expression = Expression.Lambda<Func<TInstance, bool>>(field, param);

                ParameterExpression pe = Expression.Parameter(typeof(TInstance), "x");
                MemberExpression member = Expression.Property(pe, "name");
                ConstantExpression value = Expression.Constant("Peter");
                exp = Expression.Equal(member, value);

                queryable = queryable.Where(expression);
            }

            return queryable;
        }
        */

        public static IQueryable<TInstance> SetFiltroQueryable<TInstance>(
            this IQueryable<TInstance> queryable, object filtro, bool isKeyOnly = false)
        {
            var metadata = typeof(TInstance).GetMetadata();

            var campos = isKeyOnly ? metadata.Campos.Where(x => x.IsKey()) : metadata.Campos;

            foreach (var campo in campos)
            {
                var valueObj = campo.Prop.GetValue(filtro);
                if (isKeyOnly || (!valueObj.IsValueNull()))
                {
                    var value = campo.Prop.GetValue(filtro);
                    var expression = GetEquality<TInstance>(value, new[] { campo.Prop.Name });
                    queryable = queryable.Where(expression);
                }
            }

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