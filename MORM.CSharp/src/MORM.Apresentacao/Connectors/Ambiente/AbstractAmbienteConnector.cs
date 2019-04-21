using MORM.Apresentacao.Consumers;
using MORM.Dominio.Extensoes;
using MORM.Dtos.nsAmbiente;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractAmbienteConnector : AbstractConnectorObj
    {
        public override object Executar(object instance)
        {
            var consumerDto = new ValidarAmbienteDto.Envio()
            {
                Login = instance.GetInstancePropOrField("Login") as string,
                Senha = instance.GetInstancePropOrField("Senha") as string,
            };
            var consumerApi = new AbstractApiConsumer<ValidarAmbienteDto.Envio, ValidarAmbienteDto.Retorno>();
            var retorno = consumerApi.Post(consumerDto);
            ExibirMensagem(retorno.Mensagem);
            return retorno.Conteudo.Token;
        }

        public static void ValidarAcesso()
        {
            if (string.IsNullOrWhiteSpace(AbstractApiConsumer.TokenInterno))
            {
                var acesso = new
                {
                    Login = "desen",
                    Senha = "123456"
                };
                var connector = new AbstractAmbienteConnector();
                var token = connector.Executar(acesso) as string;
                AbstractApiConsumer.SetTokenInterno(token);
            }
        }
    }
}