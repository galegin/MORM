using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao
{
    public interface IAbstractExportarConnector
    {
        object Exportar(object model);
    }

    [MTD("Exportar")]
    public class AbstractExportarConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractExportarConnector
        where TModel : class
    {
        public object Exportar(object model)
        {
            return Executar(model as TModel);
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