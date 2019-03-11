using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Commands.Tela;
using MORM.Apresentacao.Models;
using MORM.Utilidade.Extensoes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MORM.Apresentacao.ViewModels
{
    #region viewModel
    public class AbstractViewModel : AbstractNotifyPropertyChanged, IAbstractViewModel
    {
        #region construtor
        public AbstractViewModel(IAbstractModel model, IAbstractFormCommand command)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Command = command ?? throw new ArgumentNullException(nameof(command));
        }
        public AbstractViewModel()
        {
        }
        #endregion

        #region lista
        public void ClearLista()
        {
            Lista.Clear();
            NotifyAllPropertiesChanged();
        }
        public void SetLista(IList<IAbstractModel> lista)
        {
            Lista.Clear();
            foreach (var item in lista)
                Lista.Add(item);
            NotifyAllPropertiesChanged();
        }
        public ObservableCollection<IAbstractModel> Lista { get; private set; } =
            new ObservableCollection<IAbstractModel>();
        #endregion

        #region model
        public void ClearModel()
        {
            Model.ClearInstancePropAll();
            NotifyAllPropertiesChanged();
        }
        public void SetModel(IAbstractModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
        private IAbstractModel _model;
        public IAbstractModel Model
        {
            get => _model;
            set => SetField(ref _model, value);
        }
        #endregion

        #region command
        public void ClearCommand()
        {
            Command = null;
        }
        public void SetCommand(IAbstractFormCommand command)
        {
            Command = command ?? throw new ArgumentNullException(nameof(command));
        }
        public IAbstractFormCommand Command { get; private set; }
        public FecharTela FecharTela { get; private set; } = new FecharTela();
        public NavegarAnterior NavegarAnterior { get; private set; } = new NavegarAnterior();
        public NavegarPrimeiro NavegarPrimeiro { get; private set; } = new NavegarPrimeiro();
        public NavegarProximo NavegarProximo { get; private set; } = new NavegarProximo();
        public NavegarUltimo NavegarUltimo { get; private set; } = new NavegarUltimo();
        #endregion
    }
    #endregion

    #region object
    public class AbstractViewModel<TObject> : AbstractViewModel, IAbstractViewModel<TObject>
        where TObject : class, IAbstractModel
    {
        public AbstractViewModel(IAbstractModel model, IAbstractFormCommand command) : 
            base(model, command)
        {
        }
    }
    #endregion

    #region lista
    public class AbstractListaViewModel<TObject> : AbstractViewModel<IAbstractModel>
    {
        public AbstractListaViewModel(IAbstractModel model, IAbstractListaCommand command) : 
            base(model, command)
        {
        }
    }
    #endregion

    #region manut
    public class AbstractManutViewModel<TObject> : AbstractViewModel<IAbstractModel>
    {
        public AbstractManutViewModel(IAbstractModel model, IAbstractManutCommand command) : 
            base(model, command)
        {
        }
    }
    #endregion
}