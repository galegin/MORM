using MORM.Infra.CrossCutting;
using MORM.Dominio.Extensions;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractConsultarConnector<TEntrada, TRetorno> : AbstractConnectorRet<TEntrada, TRetorno>
    {
        public override TRetorno Executar(TEntrada instance)
        {
            var consumerApi = new AbstractApiConsumer<object, object>();
            var retorno = consumerApi.Post(instance, instance.GetApi(mtdPadrao: instance.GetMtd()));
            ExibirMensagem(retorno.Mensagem);
            return (TRetorno)retorno.Conteudo;
        }
    }
}