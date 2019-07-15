using MORM.Infra.CrossCutting;
using MORM.Dominio.Extensions;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractExcluirConnector<TEntrada> : AbstractConnector<TEntrada>
    {
        public override void Executar(TEntrada instance)
        {
            var consumerApi = new AbstractApiConsumer<object, object>();
            var retorno = consumerApi.Post(instance, instance.GetApi(mtdPadrao: instance.GetMtd()));
            ExibirMensagem(retorno.Mensagem);
        }
    }
}