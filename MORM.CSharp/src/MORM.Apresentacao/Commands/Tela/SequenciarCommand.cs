using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Sequenciar")]
    public class SequenciarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetSequenciarConnector();
            var retorno = connector.Sequenciar(vm.GetFiltro());
            if (retorno.IsModelChavePreenchida())
                vm.Model.CloneInstancePropOrFieldAll(retorno);
        }
    }
}