using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Excluir")]
    public class ExcluirCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;

            if (!DialogsMessages.ConfirmaExclusao.GetConfirmacao())
                return;

            var connector = vm.ElementType.GetExcluirConnector();
            connector.Excluir(vm.Model);
            vm.ClearAll();

            DialogsMessages.ExclusaoEfetuadaComSucesso.GetMensagem();
        }
    }
}