using System.Linq.Expressions;

namespace MORM.Dominio.Interfaces
{
    public interface IQueryableTranslator
    {
        string Translate(Expression expression);
    }
}