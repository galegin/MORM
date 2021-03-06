﻿using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao
{
    public interface IAbstractImportarConnector
    {
        object Importar(object model);
    }

    [MTD("Importar")]
    public class AbstractImportarConnector<TModel> : AbstractConnector<TModel, object>,
        IAbstractImportarConnector
        where TModel : class
    {
        public object Importar(object model)
        {
            return Executar(model as TModel);
        }
    }

    public static class AbstractImportarConnectorExtensions
    {
        public static IAbstractImportarConnector GetImportarConnector(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractImportarConnector<>), type)
                as IAbstractImportarConnector;
        }
    }
}