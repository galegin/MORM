using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Consultar")]
    public class AbstractConsultarConnector<TModel> : AbstractConnector<TModel, TModel>
        where TModel : class
    {
    }
}