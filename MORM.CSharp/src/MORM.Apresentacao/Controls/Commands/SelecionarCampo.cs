using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Controls.Commands
{
    public class SelecionarCampo : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractCampoViewModel;
            vm.SelecionarLista();
        }
    }
}