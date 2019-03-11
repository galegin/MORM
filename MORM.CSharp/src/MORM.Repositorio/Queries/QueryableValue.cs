﻿using MORM.Utilidade.Tipagens;
using System;
using System.Configuration;

namespace MORM.Repositorio.Queries
{
    //-- galeg - 01/10/2018 18:50:05
    public class QueryableValue : IQueryableValue
    {
        public QueryableValue()
        {
            _tipoDatabase = (TipoDatabase)Enum.Parse(typeof(TipoDatabase), ConfigurationManager.AppSettings["tipoDatabase"], false);
        }

        private readonly TipoDatabase _tipoDatabase;

        public string GetString(object value)
        {
            return _tipoDatabase.GetValueStr(value);
        }
    }
}