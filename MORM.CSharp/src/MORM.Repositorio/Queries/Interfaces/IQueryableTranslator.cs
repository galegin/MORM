using System.Linq.Expressions;

namespace MORM.Repositorio.Queries
{
    public interface IQueryableTranslator
    {
        string Translate(Expression expression);
    }
}