using MORM.Infra.CrossCutting;
using MORM.Dominio.Extensions;
using System.Collections.Generic;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractListarConnector<TEntrada, TRetorno> : AbstractConnectorList<TEntrada, TRetorno>
    {
        public override List<TRetorno> Executar(TEntrada instance)
        {
            var consumerApi = new AbstractApiConsumer<object, object>();
            var retorno = consumerApi.Post(instance, instance.GetApi(mtdPadrao: instance.GetMtd()));
            ExibirMensagem(retorno.Mensagem);
            return (List<TRetorno>)retorno.Conteudo;
        }
    }
}