using MORM.Apresentacao.Consumers;
using MORM.Dtos;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractIncluirConnector
    {
        public object Executar(object instance)
        {
            var consumerDto = new AbstractIncluirDto.Envio();
            var consumerApi = new AbstractApiConsumer<AbstractIncluirDto.Envio, object>();
            return consumerApi.Post(consumerDto).Conteudo;
        }
    }
}