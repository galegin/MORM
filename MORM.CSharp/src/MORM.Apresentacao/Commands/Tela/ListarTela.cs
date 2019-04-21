using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ListarTela<TEntrada, TRetorno> : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel<TEntrada, TRetorno>;
            var connector = new AbstractListarConnector<TEntrada, TRetorno>();
            vm.Lista = connector.Executar(vm.Filtro);
        }
    }
}