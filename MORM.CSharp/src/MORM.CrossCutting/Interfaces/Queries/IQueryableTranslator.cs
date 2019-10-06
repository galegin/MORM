using System.Linq.Expressions;

namespace MORM.CrossCutting
{
    public interface IQueryableTranslator
    {
        string Translate(Expression expression);
    }
}