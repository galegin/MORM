using MORM.CrossCutting;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Importar")]
    public class AbstractImportarConnector<TModel> : AbstractConnector<TModel, object>
        where TModel : class
    {
    }
}