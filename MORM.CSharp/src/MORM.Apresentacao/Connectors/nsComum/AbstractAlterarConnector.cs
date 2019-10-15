using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Connectors
{
    public interface IAbstractAlterarConnector
    {
        object Alterar(object model, object filtro = null);
    }

    [MTD("Alterar")]
    public class AbstractAlterarConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractAlterarConnector
        where TModel : class
    {
        public object Alterar(object model, object filtro = null)
        {
            return Executar(model as TModel, filtro);
        }
    }

    public static class AbstractAlterarConnectorExtensions
    {
        public static IAbstractAlterarConnector GetAlterarConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractAlterarConnector<>), type)
                as IAbstractAlterarConnector;
        }
    }
}