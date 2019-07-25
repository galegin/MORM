using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.ViewsModel
{
    public interface IAbstractViewModelConf
    {
        bool IsConfirmado { get; set; }
    }

    public interface IAbstractViewModelOpcao : IAbstractViewModelConf
    {
        bool IsExibirFechar { get; set; }
        bool IsExibirVoltar { get; set; }
        bool IsExibirLimpar { get; set; }
        bool IsExibirListar { get; set; }
        bool IsExibirConsultar { get; set; }
        bool IsExibirExportar { get; set; }
        bool IsExibirImportar { get; set; }
        bool IsExibirImprimir { get; set; }
        bool IsExibirIncluir { get; set; }
        bool IsExibirAlterar { get; set; }
        bool IsExibirSalvar { get; set; }
        bool IsExibirExcluir { get; set; }
        bool IsExibirRetornar { get; set; }
        bool IsExibirSelecionar { get; set; }
    }

    public interface IAbstractViewModel : IAbstractViewModelOpcao
    {
        object GetFiltro();
        void SetFiltro(object filtro);
        object GetLista();
        void SetLista(object lista);
        object GetModel();
        void SetModel(object model);
        string GetNomeFiltro();
        string GetNomeLista();
        string GetNomeModel();
        string GetTituloModel();
        void SetOpcoes(string[] opcoes);
        void ClearAll();
        void ClearFiltro();
        void ClearLista();
        void ClearModel();
        Action CloseAction { get; set; }
        Action SelecionarListaAction { get; set; }
        void RetornarModel();
        void SelecionarLista();
    }

    public interface IAbstractViewModel<TModel> : IAbstractViewModel
        where TModel : class
    {
        TModel Filtro { get; }
        TModel Model { get; }
        List<TModel> Lista { get; }
    }
}