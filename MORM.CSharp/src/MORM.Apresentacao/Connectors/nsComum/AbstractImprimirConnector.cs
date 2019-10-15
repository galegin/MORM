using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractImprimirConnector
    {
        object Imprimir(object model, object filtro = null);
    }

    [MTD("Imprimir")]
    public class AbstractImprimirConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractImprimirConnector
        where TModel : class
    {
        public object Imprimir(object model, object filtro = null)
        {
            return Executar(model as TModel, filtro);
        }
    }

    public static class AbstractImprimirConnectorExtensions
    {
        public static IAbstractImprimirConnector GetImprimirConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractImprimirConnector<>), type)
                as IAbstractImprimirConnector;
        }
    }
}