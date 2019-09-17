using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MORM.Repositorio.Queries
{
    public class Queryable<TInstance> : IQueryable<TInstance>
    {
        public Type ElementType => typeof(TInstance);
        public Expression Expression { get; }
        public IQueryProvider Provider { get; }

        public Queryable(IQueryProvider provider, Expression expression)
        {
            Provider = provider;
            Expression = expression ?? Expression.Constant(this);
        }

        public IEnumerator<TInstance> GetEnumerator()
        {
            return Provider.Execute<IEnumerable<TInstance>>(Expression).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}