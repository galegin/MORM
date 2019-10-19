using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public class LogarSistema : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as LoginViewModel;
            var loginModel = vm.Model as LoginModel;

            if (string.IsNullOrWhiteSpace(loginModel?.Login) || string.IsNullOrWhiteSpace(loginModel?.Senha))
                return;

            var model = new ValidarAmbienteInModel
            {
                Login = loginModel.Login,
                Senha = loginModel.Senha,
            };
            var connector = new AbstractAmbienteConnector();
            var token = connector.Executar(model).Token;

            vm.SetarLogin(token);
            AbstractApiConsumer.SetTokenInterno(token);
        }
    }
}