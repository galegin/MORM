using MORM.CrossCutting;
using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractListarConnector
    {
        object Listar(object model, object filtro = null);
    }

    [MTD("Listar")]
    public class AbstractListarConnector<TModel> : AbstractConnector<TModel, List<TModel>>, 
        IAbstractListarConnector
        where TModel : class
    {
        public object Listar(object model, object filtro = null)
        {
            return Executar(model as TModel, filtro);
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