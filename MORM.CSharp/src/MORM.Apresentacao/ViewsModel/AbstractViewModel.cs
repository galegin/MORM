using MORM.Apresentacao.Colors;
using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Views;
using MORM.CrossCutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModel : BaseNotifyPropertyChanged, IAbstractViewModel
    {
        #region variaveis
        #region objeto
        protected Type _elementType;
        protected object _filtro;
        protected object _model;
        protected IList _lista;
        #endregion
        #region confirmacao
        private bool _isConfirmado;
        #endregion
        #region esquema
        private AbstractEsquemaModel _esquema;
        #endregion
        #endregion

        #region propriedades
        #region objeto
        public Type ElementType
        {
            get => _elementType;
            set => SetField(ref _elementType, value);
        }
        public object Filtro
        {
            get => _filtro;
            set => SetField(ref _filtro, value);
        }
        public object Model
        {
            get => _model;
            set => SetField(ref _model, value);
        }
        public IList Lista
        {
            get => _lista;
            set => SetField(ref _lista, value);
        }
        #endregion
        #region action
        public Action CloseAction { get; set; }
        public Action SelecionarAction { get; set; }
        public Action ConfirmarAction { get; set; }
        public Action CancelarAction { get; set; }
        #endregion
        #region confirmacao
        public bool IsConfirmado
        {
            get => _isConfirmado;
            set => SetField(ref _isConfirmado, value);
        }
        #endregion
        #region esquema
        public AbstractEsquemaModel Esquema
        {
            get => _esquema;
            set => SetField(ref _esquema, value);
        }
        #endregion
        #region selecao
        public virtual object Selecao { get; set; }
        #endregion
        #endregion

        #region comandos
        public ICommand[] Commands { get; set; }
        #endregion

        #region construtores
        public AbstractViewModel()
        {
            Esquema = new AbstractEsquemaModel();
        }
        #endregion

        #region metodos
        public virtual string GetTitulo() => null;
        public virtual void ClearAll() { }

        public void SetOpcoes(string[] opcoes)
        {
            GetType()
                .GetProperties()
                .Where(x => x.Name.StartsWith("IsExibir"))
                .ToList()
                .ForEach(prop => prop.SetValue(this, opcoes.ToList().Any(x => prop.Name.EndsWith(x))));
        }

        public virtual void RetornarModel()
        {
            IsConfirmado = true;
            CloseAction?.Invoke();
        }

        public virtual void ConsultarChave() { }
        public virtual void BuscarDescricao() { }

        public virtual void SelecionarLista() => SelecionarAction?.Invoke();

        public virtual void ConfirmarTela() { }
        public virtual void CancelarTela() { }
        #endregion
    }

    public class AbstractViewModel<TModel> : AbstractViewModel, IAbstractViewModel<TModel>
        where TModel : class
    {
        #region construtores
        public AbstractViewModel() : base()
        {
            ElementType = typeof(TModel);
            Filtro = Activator.CreateInstance<TModel>();
            Lista = new List<TModel>();
            Model = Activator.CreateInstance<TModel>();
        }
        #endregion

        #region metodos
        #region metodos publicos
        public override string GetTitulo()
        {
            return
                typeof(TModel).Name
                    .Replace("Abstract", "")
                    .Replace("Model", "")
                    .Replace("View", "");
        }
        public override void ClearAll()
        {
            Filtro.ClearInstancePropOrFieldAll();
            Lista = null;
            Model?.ClearInstancePropOrFieldAll();
        }
        public override void ConsultarChave()
        {
            if (this.IsModelChavePreenchida())
            {
                var consultar = GetCommand("Consultar");
                if (consultar != null)
                    consultar.ExecuteCommand(this);
            }
        }
        #endregion
        #region metodos privados
        private ICommand GetCommand(string nome)
        {
            foreach (var command in this.Commands)
                if (command.GetType().Name.Contains(nome))
                    return command;
            return null;
        }
        #endregion
        #endregion
    }
}