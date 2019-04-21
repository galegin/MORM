using MORM.Apresentacao.Consumers;
using MORM.Dominio.Extensoes;
using MORM.Dtos;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractSalvarConnector<TEntrada> : AbstractConnector<TEntrada>
    {
        public override void Executar(TEntrada instance)
        {
            var consumerDto = new AbstractSalvarDto.Envio<TEntrada>(instance);
            var consumerApi = new AbstractApiConsumer<AbstractSalvarDto.Envio<TEntrada>, object>();
            var retorno = consumerApi.Post(consumerDto, instance.GetApi(mtdPadrao: consumerDto.GetMtd()));
            ExibirMensagem(retorno.Mensagem);
        }
    }
}