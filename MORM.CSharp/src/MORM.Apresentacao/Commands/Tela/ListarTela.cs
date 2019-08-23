using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System.Collections;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ListarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            if (!vm.IsExibirListar)
                return;

            var lista = vm.Lista;
            IList listaRet = null;

            var connector = new AbstractListarConnector<TModel>();
            var selecao = vm.Selecao as AbstractSelecao;
            if (selecao?.Valores != null)
            {
                listaRet = selecao.Valores;
            }
            else
            {
                listaRet = connector.Executar(vm.Filtro as TModel) as IList;
            }

            if (selecao?.IsSelecao ?? false)
            {
                listaRet = listaRet.GetListaSelecaoItem();
            }

            vm.Lista = null;
            vm.Lista = listaRet ?? lista;
        }
    }
}