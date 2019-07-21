using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using System.Collections.Generic;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ListarTela<TEntrada, TRetorno> : AbstractCommand
        where TEntrada : class
        where TRetorno : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractViewModel<TRetorno, TEntrada>;
            var connector = new AbstractListarConnector<TEntrada, List<TRetorno>>();
            vm.Lista = connector.Executar(vm.Filtro);
        }
    }
}