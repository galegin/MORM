using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Excluir")]
    public class AbstractExcluirConnector<TModel> : AbstractConnector<TModel, object>
        where TModel : class
    {
    }
}