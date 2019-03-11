using MORM.Apresentacao.Models;
using MORM.Apresentacao.Commands;
using System.Collections.ObjectModel;
using MORM.Apresentacao.Comps;
using System.Collections.Generic;

namespace MORM.Apresentacao.ViewModels
{
    public interface IAbstractViewModel : IAbstractNotifyPropertyChanged
    {
        void ClearLista();
        void SetLista(IList<IAbstractModel> lista);
        ObservableCollection<IAbstractModel> Lista { get; }

        void ClearModel();
        void SetModel(IAbstractModel model);
        IAbstractModel Model { get; }

        void ClearCommand();
        void SetCommand(IAbstractFormCommand command);
        IAbstractFormCommand Command { get; }
    }

    public interface IAbstractViewModel<TObject> : IAbstractViewModel
        where TObject : class, IAbstractModel
    {
    }

    public interface IAbstractListaViewModel<TObject> : IAbstractViewModel
        where TObject : class, IAbstractModel
    {
    }

    public interface IAbstractManutViewModel<TObject> : IAbstractViewModel
        where TObject : class, IAbstractModel
    {
    }
}