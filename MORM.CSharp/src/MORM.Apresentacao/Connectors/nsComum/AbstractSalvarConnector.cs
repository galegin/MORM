using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao
{
    public interface IAbstractSalvarConnector
    {
        object Salvar(object model);
    }

    [MTD("Salvar")]
    public class AbstractSalvarConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractSalvarConnector
        where TModel : class
    {
        public object Salvar(object model)
        {
            return Executar(model as TModel);
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