using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace MORM.Repositorio.Queries
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
            var instance = _dataContext.GetObjeto(typeof(TInstance), where);
            return instance.IsChavePreenchida() ? instance : default(TInstance);
        }

        internal object ExecuteList(string where)
        {
            var lista = _dataContext.GetLista(typeof(TInstance), where);
            return lista.Count > 0 ? lista : null;
        }
    }
}