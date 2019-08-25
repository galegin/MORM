using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands
{
    [Description("Inverter Seleção")]
    public class InverterSelecaoTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            foreach (var item in vm.Lista)
                (item as SelecaoItemModel)?.InverterSelecao();
        }
    }
}