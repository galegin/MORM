using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Consumers;
using MORM.Apresentacao.Login.ViewsModel;

namespace MORM.Apresentacao.Login.Commands
{
    public class LogarSistema : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as LoginViewModel;

            if (string.IsNullOrWhiteSpace(vm?.Model?.Login) || string.IsNullOrWhiteSpace(vm?.Model?.Senha))
                return;

            var dto = vm.Model;
            var connector = new AbstractAmbienteConnector();
            var token = connector.Executar(dto) as string;

            vm.SetarLogin(token);
            AbstractApiConsumer.SetTokenInterno(token);
        }
    }
}