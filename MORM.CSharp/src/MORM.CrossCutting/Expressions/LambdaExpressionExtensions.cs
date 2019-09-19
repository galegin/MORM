using System;
using System.Linq;
using System.Linq.Expressions;

namespace MORM.CrossCutting
{
    public static class LambdaExpressionExtensions
    {
        public static Expression<Func<TInput, object>> 
            ToUntypedPropertyExpression<TInput, TOutput>(this Expression<Func<TInput, TOutput>> expression)
        {
            var memberName = ((MemberExpression)expression.Body).Member.Name;

            var param = Expression.Parameter(typeof(TInput));
            var field = Expression.Property(param, memberName);
            return Expression.Lambda<Func<TInput, object>>(field, param);
        }

        public static IQueryable<TInstance> SetFiltroQueryable<TInstance>(
            this IQueryable<TInstance> queryable, object filtro)
        {
            foreach (var prop in typeof(TInstance).GetProperties())
            {
                var param = Expression.Parameter(prop.PropertyType);
                var field = Expression.Property(param, prop.Name);

                var expression = Expression.Lambda<Func<TInstance, bool>>(field, param);

                queryable = queryable.Where(expression);
            }

            return queryable;
        }
    }
}