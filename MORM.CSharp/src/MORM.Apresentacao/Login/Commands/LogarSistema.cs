using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Login.ViewsModel;
using MORM.Apresentacao.Models;
using MORM.Infra.CrossCutting;

namespace MORM.Apresentacao.Login.Commands
{
    public class LogarSistema : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as LoginViewModel;

            if (string.IsNullOrWhiteSpace(vm?.oModel?.Login) || string.IsNullOrWhiteSpace(vm?.oModel?.Senha))
                return;

            var model = new ValidarAmbienteInModel
            {
                Login = vm.oModel.Login,
                Senha = vm.oModel.Senha,
            };
            var connector = new AbstractAmbienteConnector();
            var token = connector.Executar(model).Token;

            vm.SetarLogin(token);
            AbstractApiConsumer.SetTokenInterno(token);
        }
    }
}