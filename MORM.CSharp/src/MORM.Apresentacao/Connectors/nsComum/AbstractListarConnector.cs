using MORM.CrossCutting;
using System;
using System.Collections.Generic;

namespace MORM.Apresentacao
{
    public interface IAbstractListarConnector
    {
        object Listar(object filtro);
    }

    [MTD("Listar")]
    public class AbstractListarConnector<TModel> : AbstractConnector<object, List<TModel>>, 
        IAbstractListarConnector
        where TModel : class
    {
        public object Listar(object filtro)
        {
            return Executar(filtro);
        }
    }

    public static class AbstractListarConnectorExtensions
    {
        public static IAbstractListarConnector GetListarConnector(this Type classe)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractListarConnector<>), classe)
                as IAbstractListarConnector;
        }
    }
}