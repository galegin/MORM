using MORM.Repositorio.Queries;
using MORM.Repositorio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MORM.Repositorio.Extensions
{
    public static class AbstractRepositoryExtensions
    {
        /*
        implementação dos metodos da interface IQueryableObject<TObject>
        */

        public static IQueryableObject<TObject> Where<TObject>(this IAbstractRepository<TObject> repository,
            Expression<Func<TObject, bool>> expression)
            where TObject : class
        {
            return repository.AsQueryable().Where(expression);
        }

        public static IQueryableObject<TObject> And<TObject>(this IAbstractRepository<TObject> repository,
            Expression<Func<TObject, bool>> expression)
            where TObject : class
        {
            return repository.AsQueryable().And(expression);
        }

        public static IQueryableObject<TObject> Or<TObject>(this IAbstractRepository<TObject> repository,
            Expression<Func<TObject, bool>> expression)
            where TObject : class
        {
            return repository.AsQueryable().Or(expression);
        }

        public static TObject FirstOrDefault<TObject>(this IAbstractRepository<TObject> repository, 
            Expression<Func<TObject, bool>> expression, bool relacao = true)
            where TObject : class
        {
            return repository.AsQueryable().FirstOrDefault(expression, relacao);
        }

        public static TObject FirstOrDefault<TObject>(this IAbstractRepository<TObject> repository, bool relacao = true)
            where TObject : class
        {
            return repository.AsQueryable().FirstOrDefault(relacao);
        }

        public static IList<TObject> ToList<TObject>(this IAbstractRepository<TObject> repository,
            Expression<Func<TObject, bool>> expression, bool relacao = false)
            where TObject : class
        {
            return repository.AsQueryable().ToList(expression, relacao);
        }

        public static IList<TObject> ToList<TObject>(this IAbstractRepository<TObject> repository, bool relacao = false)
            where TObject : class
        {
            return repository.AsQueryable().ToList(relacao);
        }
    }
}