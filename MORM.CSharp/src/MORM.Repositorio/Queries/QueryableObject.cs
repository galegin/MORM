using MORM.Repositorio.Extensions;
using MORM.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MORM.Repositorio.Queries
{
    public class QueryableObject<TObject> : IQueryableObject<TObject>
    {
        private readonly IAbstractDataContext _dataContext;
        private readonly IQueryableValue _value;
        private readonly IQueryableTranslator _translator;
        private readonly IList<object> _partes;

        public QueryableObject(IAbstractDataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            _value = new QueryableValue();
            _translator = new QueryableTranslator(_value);
            _partes = new List<object>();
        }

        //-- where

        public IQueryableObject<TObject> Where(Expression<Func<TObject, bool>> expression)
        {
            _partes.Add(expression);
            return this;
        }

        //-- and

        public IQueryableObject<TObject> And(Expression<Func<TObject, bool>> expression)
        {
            _partes.Add("and");
            return Where(expression);
        }

        //-- or

        public IQueryableObject<TObject> Or(Expression<Func<TObject, bool>> expression)
        {
            _partes.Add("or");
            return Where(expression);
        }

        //-- firstOrDefault

        public TObject FirstOrDefault(Expression<Func<TObject, bool>> expression, bool relacao = true)
        {
            return Where(expression).FirstOrDefault(relacao);
        }

        public TObject FirstOrDefault(bool relacao = true)
        {
            return _dataContext.GetObjetoW<TObject>(GetWhere(), relacao: relacao);
        }

        //-- toList

        public IList<TObject> ToList(Expression<Func<TObject, bool>> expression, bool relacao = false)
        {
            return Where(expression).ToList(relacao: relacao);
        }

        public IList<TObject> ToList(bool relacao = false)
        {
            return _dataContext.GetListaW<TObject>(GetWhere(), relacao: relacao);
        }

        //-- where

        private string GetWhere()
        {
            var where = new List<string>();
            var contemAndOr = _partes.Any(x => x is string);

            foreach (var parte in _partes)
            {
                if (parte is Expression<Func<TObject, bool>>)
                {
                    where.Add(_translator.Translate(parte as Expression<Func<TObject, bool>>));
                }
                else if (parte is string)
                {
                    where.Add(parte as string);
                }
            }

            return string.Join(contemAndOr ? " " : " and ", where);
        }
    }
}