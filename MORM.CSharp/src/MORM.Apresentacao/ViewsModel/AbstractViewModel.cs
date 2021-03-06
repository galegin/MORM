﻿using MORM.CrossCutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MORM.Apresentacao
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
        public Action FecharAction { get; set; }
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
        #region grade
        public virtual object Grade { get; set; }
        #endregion
        #region expressao
        public virtual string Expressao { get; set; }
        #endregion
        #region clausula
        public virtual string Clausula { get; set; }
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
            FecharAction?.Invoke();
        }

        public virtual void ConsultarChave() { }
        public virtual void BuscarDescricao() { }

        public virtual void LimparLista() { }
        public virtual void ConsultarLista() { }
        public virtual void SelecionarLista() => SelecionarAction?.Invoke();

        public virtual void ConfirmarTela() => ConfirmarAction?.Invoke();
        public virtual void CancelarTela() => ConfirmarAction?.Invoke();

        public virtual void FecharTela() => FecharAction?.Invoke();
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
                var command = GetCommand("Consultar");
                command?.ExecuteCommand(this);
            }
        }
        public override void LimparLista()
        {
            var command = Commands.FirstOrDefault(x => x is LimparCommand);
            command?.ExecuteCommand(this);
        }
        public override void ConsultarLista()
        {
            var command = Commands.FirstOrDefault(x => x is ListarCommand);
            command?.ExecuteCommand(this);
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