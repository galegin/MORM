using MORM.Apresentacao.Models;
using MORM.Dominio.Extensions;
using MORM.Infra.CrossCutting;
using System.Configuration;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractAmbienteConnector : AbstractConnectorObj
    {
        private static string _token = ConfigurationManager.AppSettings[nameof(_token)] ?? string.Empty;

        public override object Executar(object instance)
        {
            var consumerDto = new ValidarAmbienteInModel
            {
                Login = instance.GetInstancePropOrField("Login") as string,
                Senha = instance.GetInstancePropOrField("Senha") as string,
            };
            var consumerApi = new AbstractApiConsumer<ValidarAmbienteInModel, ValidarAmbienteOutModel>();
            var retorno = consumerApi.Post(consumerDto);
            ExibirMensagem(retorno.Mensagem);
            return retorno.Conteudo.GetInstancePropOrField("Token");
        }

        public static void ValidarAcesso()
        {
            if (string.IsNullOrWhiteSpace(AbstractApiConsumer.TokenInterno) && !string.IsNullOrWhiteSpace(_token))
                AbstractApiConsumer.SetTokenInterno(_token);

            if (string.IsNullOrWhiteSpace(AbstractApiConsumer.TokenInterno))
            {
                var acesso = new
                {
                    Login = "ADMIN",
                    Senha = "admin"
                };
                var connector = new AbstractAmbienteConnector();
                var token = connector.Executar(acesso) as string;
                AbstractApiConsumer.SetTokenInterno(token);
            }
        }
    }
}