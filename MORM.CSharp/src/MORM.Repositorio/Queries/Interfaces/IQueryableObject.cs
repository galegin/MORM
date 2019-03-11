using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MORM.Repositorio.Queries
{
    //-- galeg - 16/09/2018 09:48:53

    public interface IQueryableObject<TObject>
        where TObject : class
    {
        IQueryableObject<TObject> Where(Expression<Func<TObject, bool>> expression);
        IQueryableObject<TObject> And(Expression<Func<TObject, bool>> expression);
        IQueryableObject<TObject> Or(Expression<Func<TObject, bool>> expression);
        TObject FirstOrDefault(Expression<Func<TObject, bool>> expression, bool relacao = true);
        TObject FirstOrDefault(bool relacao = true);
        IList<TObject> ToList(Expression<Func<TObject, bool>> expression, bool relacao = false);
        IList<TObject> ToList(bool relacao = false);
    }
}