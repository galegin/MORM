using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Incluir")]
    public class IncluirCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;

            if (!DialogsMessages.ConfirmaInclusao.GetConfirmacao())
                return;

            var connector = vm.ElementType.GetIncluirConnector();
            connector.Incluir(vm.Model);

            DialogsMessages.InclusaoEfetuadaComSucesso.GetMensagem();
        }
    }
}