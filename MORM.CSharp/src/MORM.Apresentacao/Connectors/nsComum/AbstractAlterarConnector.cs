using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao
{
    public interface IAbstractAlterarConnector
    {
        object Alterar(object model);
    }

    [MTD("Alterar")]
    public class AbstractAlterarConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractAlterarConnector
        where TModel : class
    {
        public object Alterar(object model)
        {
            return Executar(model as TModel);
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