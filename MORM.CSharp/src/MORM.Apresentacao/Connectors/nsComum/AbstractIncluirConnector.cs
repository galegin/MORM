using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractIncluirConnector
    {
        object Incluir(object model, object filtro = null);
    }

    [MTD("Incluir")]
    public class AbstractIncluirConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractIncluirConnector
        where TModel : class
    {
        public object Incluir(object model, object filtro = null)
        {
            return Executar(model as TModel, filtro);
        }
    }

    public static class AbstractIncluirConnectorExtensions
    {
        public static IAbstractIncluirConnector GetIncluirConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractIncluirConnector<>), type)
                as IAbstractIncluirConnector;
        }
    }
}