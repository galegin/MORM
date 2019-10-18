using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractConsultarConnector
    {
        object Consultar(object filtro);
    }

    [MTD("Consultar")]
    public class AbstractConsultarConnector<TModel> : AbstractConnector<object, TModel>, 
        IAbstractConsultarConnector
        where TModel : class
    {
        public object Consultar(object filtrro)
        {
            return Executar(filtrro);
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