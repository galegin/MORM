using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.ViewsModel
{
    public interface IAbstractViewModel
    {
        object GetModel();
        string GetNomeModel();
        string GetTituloModel();
        Action CloseAction { get; set; }
    }

    public interface IAbstractViewModel<TModel, TFiltro> : IAbstractViewModel
        where TModel : class
        where TFiltro : class
    {
        TModel Model { get; }
        TFiltro Filtro { get; }
        List<TModel> Lista { get; }
    }
}