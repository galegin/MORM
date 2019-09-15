using MORM.Dominio.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MORM.Repositorio.Queries
{
    public class QueryProvider<TInstance> : IQueryProvider
    {
        private IQueryableObject<TInstance> _queryableObject;

        public QueryProvider(IQueryableObject<TInstance> queryableObject)
        {
            _queryableObject = queryableObject;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            throw new NotImplementedException();
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}