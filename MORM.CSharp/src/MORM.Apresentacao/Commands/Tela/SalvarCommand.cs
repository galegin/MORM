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
            var connector = vm.ElementType.GetSalvarConnector();
            vm.Model.SetCampoPadrao();
            connector.Salvar(vm.Model);
        }
    }
}