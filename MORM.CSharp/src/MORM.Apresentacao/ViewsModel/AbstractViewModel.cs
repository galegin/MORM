using MORM.Apresentacao.Colors;
using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Views;
using MORM.Dominio.Extensions;
using MORM.Infra.CrossCutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModel : BaseNotifyPropertyChanged, IAbstractViewModel
    {
        #region variaveis
        #region objeto
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
        public virtual Type ElementType => Model.GetType();
        public virtual object Filtro
        {
            get => _filtro;
            set => SetField(ref _filtro, value);
        }
        public virtual object Model
        {
            get => _model;
            set => SetField(ref _model, value);
        }
        public virtual IList Lista
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
            //Fechar.ExecuteCommand(this);
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
        #region propriedades
        public override Type ElementType => typeof(TModel);
        public TModel oFiltro
        {
            get => _filtro as TModel;
            set => SetField(ref _filtro, value);
        }
        public List<TModel> oLista
        {
            get => _lista as List<TModel>;
            set => SetField(ref _lista, value);
        }
        public TModel oModel
        {
            get => _model as TModel;
            set => SetField(ref _model, value);
        }
        #endregion

        #region construtores
        public AbstractViewModel() : base()
        {
            Filtro = Activator.CreateInstance<TModel>();
            Lista = new List<TModel>();
            Model = Activator.CreateInstance<TModel>();
        }
        #endregion

        #region metodos
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
                //Consultar.ExecuteCommand(this);
            }
        }
        public void SetarAtualizacao()
        {
            oModel?.SetCampoPadrao();
        }
        #endregion
    }
}