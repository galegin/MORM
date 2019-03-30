using MORM.Apresentacao.Consumers;
using MORM.Dtos;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractExcluirConnector
    {
        public object Executar(object instance)
        {
            var consumerDto = new AbstractExcluirDto.Envio();
            var consumerApi = new AbstractApiConsumer<AbstractExcluirDto.Envio, object>();
            return consumerApi.Post(consumerDto).Conteudo;
        }
    }
}