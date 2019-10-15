using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractSalvarConnector
    {
        object Salvar(object model, object filtro = null);
    }

    [MTD("Salvar")]
    public class AbstractSalvarConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractSalvarConnector
        where TModel : class
    {
        public object Salvar(object model, object filtro = null)
        {
            return Executar(model as TModel, filtro);
        }
    }

    public static class AbstractSalvarConnectorExtensions
    {
        public static IAbstractSalvarConnector GetSalvarConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractSalvarConnector<>), type)
                as IAbstractSalvarConnector;
        }
    }
}