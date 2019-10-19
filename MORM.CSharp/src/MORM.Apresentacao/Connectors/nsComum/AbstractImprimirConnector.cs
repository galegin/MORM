using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao
{
    public interface IAbstractImprimirConnector
    {
        object Imprimir(object model);
    }

    [MTD("Imprimir")]
    public class AbstractImprimirConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractImprimirConnector
        where TModel : class
    {
        public object Imprimir(object model)
        {
            return Executar(model as TModel);
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