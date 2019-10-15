using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractExportarConnector
    {
        object Exportar(object model, object filtro = null);
    }

    [MTD("Exportar")]
    public class AbstractExportarConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractExportarConnector
        where TModel : class
    {
        public object Exportar(object model, object filtro = null)
        {
            return Executar(model as TModel, filtro);
        }
    }

    public static class AbstractExportarConnectorExtensions
    {
        public static IAbstractExportarConnector GetExportarConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractExportarConnector<>), type)
                as IAbstractExportarConnector;
        }
    }
}