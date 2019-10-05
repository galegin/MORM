using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands
{
    [Description("Inverter")]
    public class InverterSelecaoCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            vm.Lista.SetInverterSelecao();
        }
    }
}