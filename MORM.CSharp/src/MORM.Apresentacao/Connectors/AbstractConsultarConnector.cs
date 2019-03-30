using MORM.Apresentacao.Consumers;
using MORM.Dtos;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractConsultarConnector
    {
        public object Executar(object instance)
        {
            var consumerDto = new AbstractConsultarDto.Envio();
            var consumerApi = new AbstractApiConsumer<AbstractConsultarDto.Envio, AbstractConsultarDto.Retorno>();
            return consumerApi.Post(consumerDto).Conteudo;
        }
    }
}