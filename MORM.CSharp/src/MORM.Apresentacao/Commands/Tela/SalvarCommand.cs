using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Salvar")]
    public class SalvarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = new AbstractSalvarConnector<object>();
            vm.Model.SetCampoPadrao();
            connector.Executar(vm.Model);
        }
    }
}