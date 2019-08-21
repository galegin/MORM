using MORM.Apresentacao.Comps;
using MORM.Apresentacao.ViewsModel;
using MORM.Infra.CrossCutting;
using System;
using System.Collections;

namespace MORM.Apresentacao.Views
{
    public static class AbstractViewListaExtensions
    {
        public static object Execute(Type classe, object objeto, 
            IList valores = null, bool isSelecao = false)
        {
            var clasLista = new Type[] { classe };
            var argsLista = new object[] { valores, isSelecao };

            var viewLista = TypeForConvert
                .GetObjectFor(typeof(AbstractViewLista<>), clasLista, argsLista) as AbstractViewLista;

            //if (valores != null)
            //    viewLista.SetValores(valores);
            //if (isSelecao)
            //    viewLista.SetSelecao();

            if (TelaUtils.Instance.AbrirDialog(viewLista, isFullScreen: true) == true)
                return null;

            var vmLista = viewLista.DataContext as IAbstractViewModel;
            if (!vmLista.IsConfirmado)
                return null;

            return ObjetoMapper.GetObjetoRetorno(vmLista.Model.GetType(), vmLista.Model);
        }

        public static object Execute<TViewModel>(object objeto)
            where TViewModel : IAbstractViewModel
        {
            return Execute(typeof(TViewModel), objeto);
        }
    }
}