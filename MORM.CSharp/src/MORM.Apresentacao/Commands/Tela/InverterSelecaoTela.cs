using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands
{
    [Description("Inverter")]
    public class InverterSelecaoTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            vm.Lista.SetInverterSelecao();
        }
    }
}