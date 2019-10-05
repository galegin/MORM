using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System.Collections;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Listar")]
    public class ListarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetListarConnector();
            var selecao = vm.Selecao as AbstractSelecao;
            var listaRet = selecao?.Valores;
            var lista = vm.Lista;

            if (listaRet == null)
            {
                listaRet = connector.ExecutarLista(vm.Model, filtro: vm.Filtro) as IList;
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