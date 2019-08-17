using MORM.Infra.CrossCutting;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Alterar")]
    public class AbstractAlterarConnector<TModel> : AbstractConnector<TModel, object> 
        where TModel : class
    {
    }
}