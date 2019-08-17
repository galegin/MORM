using MORM.Infra.CrossCutting;
using System.Collections.Generic;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Listar")]
    public class AbstractListarConnector<TModel> : AbstractConnector<TModel, List<TModel>>
        where TModel : class
    {
    }
}