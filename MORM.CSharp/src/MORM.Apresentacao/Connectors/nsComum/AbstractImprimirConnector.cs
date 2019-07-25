using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Imprimir")]
    public class AbstractImprimirConnector<TModel> : AbstractConnector<TModel, object>
        where TModel : class
    {
    }
}