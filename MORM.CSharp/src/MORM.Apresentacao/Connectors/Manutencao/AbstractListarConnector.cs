using MORM.Apresentacao.Consumers;
using MORM.Dominio.Extensoes;
using MORM.Dtos;
using System.Collections.Generic;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractListarConnector<TEntrada, TRetorno> : AbstractConnectorList<TEntrada, TRetorno>
    {
        public override List<TRetorno> Executar(TEntrada instance)
        {
            var consumerDto = new AbstractListarDto.Envio<TEntrada>(instance);
            var consumerApi = new AbstractApiConsumer<AbstractListarDto.Envio<TEntrada>, AbstractListarDto.Retorno<TRetorno>>();
            var retorno = consumerApi.Post(consumerDto, instance.GetApi(mtdPadrao: consumerDto.GetMtd()));
            ExibirMensagem(retorno.Mensagem);
            return retorno.Conteudo.Lista;
        }
    }
}