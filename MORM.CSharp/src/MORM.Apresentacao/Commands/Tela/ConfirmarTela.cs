using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Confirmar")]
    public class ConfirmarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            vm.ConfirmarTela();
        }
    }
}