﻿using System.Collections;
using System.ComponentModel;

namespace MORM.Apresentacao
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
                listaRet = connector.Listar(vm.GetFiltro()) as IList;
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