using MORM.CrossCutting;
using System;
using System.Collections;

namespace MORM.Apresentacao
{
    public static class AbstractViewManutExtensions
    {
        public static object Execute(Type classe, object objeto, IList valores = null)
        {
            var viewLista = TypeForConvert
                .GetObjectFor(typeof(AbstractViewManut<>), classe) as AbstractViewManut;

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