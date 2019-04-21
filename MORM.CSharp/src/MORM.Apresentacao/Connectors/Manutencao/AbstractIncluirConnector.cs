using MORM.Apresentacao.Consumers;
using MORM.Dominio.Extensoes;
using MORM.Dtos;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractIncluirConnector<TEntrada> : AbstractConnector<TEntrada>
    {
        public override void Executar(TEntrada instance)
        {
            var consumerDto = new AbstractIncluirDto.Envio<TEntrada>(instance);
            var consumerApi = new AbstractApiConsumer<AbstractIncluirDto.Envio<TEntrada>, object>();
            var retorno = consumerApi.Post(consumerDto, instance.GetApi(mtdPadrao: consumerDto.GetMtd()));
            ExibirMensagem(retorno.Mensagem);
        }
    }
}