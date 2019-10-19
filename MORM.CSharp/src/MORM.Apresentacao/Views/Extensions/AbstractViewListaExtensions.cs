using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao
{
    public static class AbstractViewListaExtensions
    {
        public static object Execute(Type classe, object objeto, 
            AbstractSelecao selecao = null)
        {
            var clasLista = new Type[] { classe };
            var argsLista = new object[] { selecao };

            var viewLista = TypeForConvert
                .GetObjectForArg(typeof(AbstractViewLista<>), clasLista, argsLista) as AbstractViewLista;

            if (TelaUtils.Instance.AbrirDialog(viewLista, isFullScreen: true) == true)
                return null;

            var vmLista = viewLista.DataContext as IAbstractViewModel;
            if (!vmLista.IsConfirmado)
                return null;

            if (selecao?.IsSelecao ?? false)
            {
                return vmLista.Lista.GetListaSelecaoItemCodigo();
            }

            return ObjetoMapper.GetObjetoRetorno(vmLista.Model.GetType(), vmLista.Model);
        }

        public static object Execute<TViewModel>(object objeto)
            where TViewModel : IAbstractViewModel
        {
            return Execute(typeof(TViewModel), objeto);
        }
    }
}