﻿using System.Collections.Generic;

namespace MORM.Apresentacao.ViewsModel
{
    public interface IAbstractViewModel
    {
        object GetModel();
        string GetNomeModel();
        string GetTituloModel();
    }

    public interface IAbstractViewModel<TModel> : IAbstractViewModel
    {
        TModel Model { get; }
    }

    public interface IAbstractViewModel<TFiltro, TModel> : IAbstractViewModel<TModel>
    {
        TFiltro Filtro { get; }
        List<TModel> Lista { get; }
    }
}