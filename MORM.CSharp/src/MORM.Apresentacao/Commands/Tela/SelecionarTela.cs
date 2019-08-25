using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Selecionar")]
    public class SelecionarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            vm.SelecionarLista();
        }
    }
}