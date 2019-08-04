using System;
using System.Collections;
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
        bool IsExibirConfirmar { get; set; }
        bool IsExibirCancelar { get; set; }
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
        Type ElementType { get; }
        object Filtro { get; set; }
        object Model { get; set; }
        IList Lista { get; set; }
        string GetTitulo();
        void ClearAll();
        void SetOpcoes(string[] opcoes);
        Action CloseAction { get; set; }
        Action SelecionarAction { get; set; }
        Action ConfirmarAction { get; set; }
        Action CancelarAction { get; set; }
        void RetornarModel();
        void ConsultarChave();
        void SelecionarLista();
        void BuscarDescricao();
        void GerarIntervalo();
        void ConfirmarTela();
        void CancelarTela();
    }

    public interface IAbstractViewModel<TModel> : IAbstractViewModel
        where TModel : class
    {
        TModel oFiltro { get; set; }
        TModel oModel { get; set; }
        List<TModel> oLista { get; set; }
    }
}