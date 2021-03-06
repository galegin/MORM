﻿using System;
using System.Collections;
using System.Windows.Input;

namespace MORM.Apresentacao
{
    public interface IAbstractViewModelConf
    {
        bool IsConfirmado { get; set; }
    }

    public interface IAbstractViewModelOpcao : IAbstractViewModelConf
    {
    }

    public interface IAbstractViewModel : IAbstractViewModelOpcao
    {
        Type ElementType { get; }
        object Filtro { get; set; }
        object Model { get; set; }
        object Selecao { get; set; }
        object Grade { get; set; } // para uso do report
        string Expressao { get; set; }
        string Clausula { get; set; }
        IList Lista { get; set; }
        ICommand[] Commands { get; set; }
        string GetTitulo();
        void ClearAll();
        void SetOpcoes(string[] opcoes);
        Action FecharAction { get; set; }
        Action SelecionarAction { get; set; }
        Action ConfirmarAction { get; set; }
        Action CancelarAction { get; set; }
        void RetornarModel();
        void ConsultarChave();
        void LimparLista();
        void ConsultarLista();
        void SelecionarLista();
        void BuscarDescricao();
        void ConfirmarTela();
        void CancelarTela();
        void FecharTela();
    }

    public interface IAbstractViewModel<TModel> : IAbstractViewModel
        where TModel : class
    {
    }
}