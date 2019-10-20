using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Alterar")]
    public class AlterarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;

            if (!DialogsMessages.ConfirmaAlteracao.GetConfirmacao())
                return;

            var connector = vm.ElementType.GetAlterarConnector();
            connector.Alterar(vm.Model);

            DialogsMessages.AlteracaoEfetuadaComSucesso.GetMensagem();
        }
    }
}