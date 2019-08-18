using MORM.Infra.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractConsultarConnector
    {
    }

    [MTD("Consultar")]
    public class AbstractConsultarConnector<TModel> : AbstractConnector<TModel, TModel>, IAbstractConsultarConnector
        where TModel : class
    {
    }

    public static class AbstractConsultarConnectorExtensions
    {
        public static IAbstractConsultarConnector GetConsultarConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractConsultarConnector<>), type) as IAbstractConsultarConnector;
        }
    }
}