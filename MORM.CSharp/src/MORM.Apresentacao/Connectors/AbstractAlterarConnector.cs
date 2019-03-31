using MORM.Apresentacao.Consumers;
using MORM.Dtos;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractAlterarConnector
    {
        public object Executar(object instance)
        {
            var consumerDto = new AbstractAlterarDto.Envio();
            var consumerApi = new AbstractApiConsumer<AbstractAlterarDto.Envio, object>();
            return consumerApi.Post(consumerDto).Conteudo;
        }
    }
}