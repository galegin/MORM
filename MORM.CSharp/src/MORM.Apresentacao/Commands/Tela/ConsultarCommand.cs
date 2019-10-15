using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.ViewsModel;
using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Consultar")]
    public class ConsultarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetConsultarConnector();
            var retorno = connector.Consultar(vm.Model);
            if (retorno.IsModelChavePreenchida())
                vm.Model.CloneInstancePropOrFieldAll(retorno);
        }
    }
}