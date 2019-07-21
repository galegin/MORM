using MORM.Apresentacao.ViewsModel;
using MORM.Dominio.Extensions;

namespace MORM.Apresentacao.Commands.Tela
{
    public class LimparTela<TEntrada> : AbstractCommand
        where TEntrada : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractViewModel<TEntrada, TEntrada>;
            vm.Model.ClearInstancePropOrFieldAll();
        }
    }
}