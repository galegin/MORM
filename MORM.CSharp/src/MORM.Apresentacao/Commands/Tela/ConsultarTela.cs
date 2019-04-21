using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;
using MORM.Dominio.Extensoes;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ConsultarTela<TEntrada> : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel<TEntrada>;
            var connector = new AbstractConsultarConnector<TEntrada, TEntrada>();
            var retorno = connector.Executar(vm.Model);
            vm.Model.CloneInstancePropOrFieldAll(retorno);
        }
    }
}