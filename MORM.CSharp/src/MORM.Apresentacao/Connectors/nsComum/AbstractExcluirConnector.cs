using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractExcluirConnector
    {
        object Excluir(object model);
    }

    [MTD("Excluir")]
    public class AbstractExcluirConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractExcluirConnector
        where TModel : class
    {
        public object Excluir(object model)
        {
            return Executar(model as TModel);
        }
    }

    public static class AbstractExcluirConnectorExtensions
    {
        public static IAbstractExcluirConnector GetExcluirConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractExcluirConnector<>), type)
                as IAbstractExcluirConnector;
        }
    }
}