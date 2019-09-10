using MORM.CrossCutting;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Incluir")]
    public class AbstractIncluirConnector<TModel> : AbstractConnector<TModel, object>
        where TModel : class
    {
    }
}