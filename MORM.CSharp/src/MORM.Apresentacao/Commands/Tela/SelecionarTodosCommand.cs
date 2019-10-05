using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands
{
    [Description("Todos")]
    public class SelecionarTodosCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            vm.Lista.SetSelecionarTodos();
        }
    }
}