using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractImportarConnector
    {
        object Importar(object model, object filtro = null);
    }

    [MTD("Importar")]
    public class AbstractImportarConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractImportarConnector
        where TModel : class
    {
        public object Importar(object model, object filtro = null)
        {
            return Executar(model as TModel, filtro);
        }
    }

    public static class AbstractImportarConnectorExtensions
    {
        public static IAbstractImportarConnector GetImportarConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractImportarConnector<>), type)
                as IAbstractImportarConnector;
        }
    }
}