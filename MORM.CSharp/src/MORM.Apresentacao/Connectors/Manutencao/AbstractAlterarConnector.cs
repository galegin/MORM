using MORM.Apresentacao.Consumers;
using MORM.Dominio.Extensoes;
using MORM.Dtos;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractAlterarConnector<TEntrada> : AbstractConnector<TEntrada>
    {
        public override void Executar(TEntrada instance)
        {
            var consumerDto = new AbstractAlterarDto.Envio<TEntrada>(instance);
            var consumerApi = new AbstractApiConsumer<AbstractAlterarDto.Envio<TEntrada>, object>();
            var retorno = consumerApi.Post(consumerDto, instance.GetApi(mtdPadrao: consumerDto.GetMtd()));
            ExibirMensagem(retorno.Mensagem);
        }
    }
}