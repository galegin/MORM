using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractIncluirConnector
    {
        object Incluir(object model);
    }

    [MTD("Incluir")]
    public class AbstractIncluirConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractIncluirConnector
        where TModel : class
    {
        public object Incluir(object model)
        {
            return Executar(model as TModel);
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