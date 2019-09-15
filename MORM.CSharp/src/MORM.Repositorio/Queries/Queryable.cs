using MORM.Dominio.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MORM.Repositorio.Queries
{
    public class Queryable<TInstance> : IQueryable<TInstance>
    {
        private IQueryableObject<TInstance> _queryableObject;

        public Expression Expression { get; }
        public Type ElementType => typeof(TInstance);
        public IQueryProvider Provider { get; }

        public Queryable(IQueryableObject<TInstance> queryableObject)
        {
            _queryableObject = queryableObject;

            Expression = new QueryExpression();
            Provider = new QueryProvider<TInstance>(queryableObject);
        }

        public IEnumerator<TInstance> GetEnumerator()
        {
            return _queryableObject.ToList().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queryableObject.ToList().GetEnumerator();
        }
    }
}