using MORM.Apresentacao.Consumers;
using MORM.Dtos;
using System.Collections.Generic;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractListarConnector
    {
        public object Executar(object instance)
        {
            var consumerDto = new AbstractListarDto.Envio();
            var consumerApi = new AbstractApiConsumer<AbstractListarDto.Envio, List<AbstractListarDto.Retorno>>();
            return consumerApi.Post(consumerDto).Conteudo;
        }
    }
}