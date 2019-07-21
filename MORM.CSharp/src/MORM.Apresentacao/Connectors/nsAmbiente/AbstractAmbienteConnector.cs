using MORM.Apresentacao.Models;
using MORM.Infra.CrossCutting;
using System.Configuration;

namespace MORM.Apresentacao.Connectors
{
    public class AbstractAmbienteConnector : AbstractConnector<ValidarAmbienteInModel, ValidarAmbienteOutModel>
    {
        private static string _token = ConfigurationManager.AppSettings[nameof(_token)] ?? string.Empty;

        public override ValidarAmbienteOutModel Executar(ValidarAmbienteInModel instance)
        {
            var consumerApi = new AbstractApiConsumer<ValidarAmbienteInModel, ValidarAmbienteOutModel>();
            var retorno = consumerApi.Post(instance);
            ExibirMensagem(retorno.Mensagem);
            return retorno.Conteudo;
        }

        public static void ValidarAcesso()
        {
            if (string.IsNullOrWhiteSpace(AbstractApiConsumer.TokenInterno) && !string.IsNullOrWhiteSpace(_token))
                AbstractApiConsumer.SetTokenInterno(_token);

            if (!string.IsNullOrWhiteSpace(AbstractApiConsumer.TokenInterno))
                return;

            var acesso = new ValidarAmbienteInModel
            {
                Login = "ADMIN",
                Senha = "admin"
            };
            var connector = new AbstractAmbienteConnector();
            var token = connector.Executar(acesso).Token;
            AbstractApiConsumer.SetTokenInterno(token);
        }
    }
}