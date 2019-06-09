using MORM.Apresentacao.ViewsModel;
using MORM.Dominio.Extensoes;

namespace MORM.Apresentacao.Commands.Tela
{
    public class LimparTela<TEntrada> : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractViewModel<TEntrada>;
            vm.Model.ClearInstancePropOrFieldAll();
        }
    }
}