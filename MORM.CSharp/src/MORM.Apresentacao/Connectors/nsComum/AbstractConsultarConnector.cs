using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractConsultarConnector
    {
        object ExecutarConsulta(object model, object filtro = null);
    }

    [MTD("Consultar")]
    public class AbstractConsultarConnector<TModel> : AbstractConnector<TModel, TModel>, 
        IAbstractConsultarConnector
        where TModel : class
    {
        public object ExecutarConsulta(object model, object filtro = null)
        {
            return Executar(model as TModel, filtro);
        }
    }

    public static class AbstractConsultarConnectorExtensions
    {
        public static IAbstractConsultarConnector GetConsultarConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractConsultarConnector<>), type) 
                as IAbstractConsultarConnector;
        }
    }
}