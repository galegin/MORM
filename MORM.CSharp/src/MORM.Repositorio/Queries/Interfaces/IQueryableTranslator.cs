using System.Linq.Expressions;

namespace MORM.Repositorio.Queries
{
    //-- galeg - 01/10/2018 18:46:25
    public interface IQueryableTranslator
    {
        string Translate(Expression expression);
    }
}