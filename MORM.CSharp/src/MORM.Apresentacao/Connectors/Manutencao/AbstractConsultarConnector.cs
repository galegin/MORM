using MORM.Apresentacao.Consumers;
using MORM.Dominio.Extensoes;
using MORM.Dtos;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractConsultarConnector<TEntrada, TRetorno> : AbstractConnectorRet<TEntrada, TRetorno>
    {
        public override TRetorno Executar(TEntrada instance)
        {
            var consumerDto = new AbstractConsultarDto.Envio<TEntrada>(instance);
            var consumerApi = new AbstractApiConsumer<AbstractConsultarDto.Envio<TEntrada>, AbstractConsultarDto.Retorno<TRetorno>>();
            var retorno = consumerApi.Post(consumerDto, instance.GetApi(mtdPadrao: consumerDto.GetMtd()));
            ExibirMensagem(retorno.Mensagem);
            return retorno.Conteudo.Objeto;
        }
    }
}