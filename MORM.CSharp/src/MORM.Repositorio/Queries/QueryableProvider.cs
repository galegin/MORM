﻿using MORM.CrossCutting;
using System.Linq;
using System.Linq.Expressions;

namespace MORM.Repositorio
{
    public class QueryableProvider<TInstance> : IQueryProvider
    {
        private IAbstractDataContext _dataContext;

        public QueryableProvider(IAbstractDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new Queryable<TInstance>(this, expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new Queryable<TElement>(this, expression);
        }

        public object Execute(Expression expression)
        {
            return Execute<TInstance>(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            var isEnumerable = (typeof(TResult).Name == "IEnumerable`1");
            return (TResult) Execute(expression, isEnumerable);
        }
               
        internal object Execute(Expression expression, bool isEnumerable)
        {
            var where = new QueryableTranslator().Translate(expression);

            if (isEnumerable)
                return ExecuteList(where);
            else
                return ExecuteInstance(where);
        }

        internal object ExecuteInstance(string where)
        {
            return _dataContext.GetObjeto(typeof(TInstance), where);
        }

        internal object ExecuteList(string where)
        {
            return _dataContext.GetLista(typeof(TInstance), where);
        }
    }
}