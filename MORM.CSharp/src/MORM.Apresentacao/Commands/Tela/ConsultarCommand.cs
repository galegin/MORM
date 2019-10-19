using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Consultar")]
    public class ConsultarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetConsultarConnector();
            var retorno = connector.Consultar(vm.GetFiltro());
            if (retorno.IsModelChavePreenchida())
                vm.Model.CloneInstancePropOrFieldAll(retorno);
        }
    }
}