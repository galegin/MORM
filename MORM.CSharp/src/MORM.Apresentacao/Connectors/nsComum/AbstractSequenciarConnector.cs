using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao
{
    public interface IAbstractSequenciarConnector
    {
        object Sequenciar(object filtro);
    }

    [MTD("Sequenciar")]
    public class AbstractSequenciarConnector<TModel> : AbstractConnector<object, TModel>, 
        IAbstractSequenciarConnector
        where TModel : class
    {
        public object Sequenciar(object filtrro)
        {
            return Executar(filtrro);
        }
    }

    public static class AbstractSequenciarConnectorExtensions
    {
        public static IAbstractSequenciarConnector GetSequenciarConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractSequenciarConnector<>), type) 
                as IAbstractSequenciarConnector;
        }
    }
}