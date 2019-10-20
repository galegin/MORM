using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Salvar")]
    public class SalvarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;

            if (!DialogsMessages.ConfirmaGravacao.GetConfirmacao())
                return;

            var connector = vm.ElementType.GetSalvarConnector();
            vm.Model.SetCampoPadrao();
            connector.Salvar(vm.Model);

            DialogsMessages.GravacaoEfetuadaComSucesso.GetMensagem();
        }
    }
}