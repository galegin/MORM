using MORM.Apresentacao.Consumers;
using MORM.Dtos;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractSalvarConnector
    {
        public object Executar(object instance)
        {
            var consumerDto = new AbstractSalvarDto.Envio();
            var consumerApi = new AbstractApiConsumer<AbstractSalvarDto.Envio, object>();
            return consumerApi.Post(consumerDto).Conteudo;
        }
    }
}