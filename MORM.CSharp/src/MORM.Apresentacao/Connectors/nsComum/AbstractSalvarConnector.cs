using MORM.CrossCutting;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Salvar")]
    public class AbstractSalvarConnector<TModel> : AbstractConnector<TModel, object>
        where TModel : class
    {
    }
}