using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Exportar")]
    public class AbstractExportarConnector<TModel> : AbstractConnector<TModel, object>
        where TModel : class
    {
    }
}