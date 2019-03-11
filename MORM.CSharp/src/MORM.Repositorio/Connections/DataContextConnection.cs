using MORM.Utilidade.Interfaces;
using MORM.Utilidade.Tipagens;
using System;
using System.Collections.Generic;

namespace MORM.Repositorio.Context
{
    //-- galeg - 30/04/2018 20:07:26
    public class DataContextConnection
    {
        private static Dictionary<TipoDatabase, IConnectionFactory> _listaDeConnectionFactory =
            new Dictionary<TipoDatabase, IConnectionFactory>();

        public static void SetConnectionFactory(TipoDatabase tipoDatabase, IConnectionFactory connectionFactory)
        {
            _listaDeConnectionFactory[tipoDatabase] = connectionFactory;
        }

        public static IConnectionFactory GetConnection(IAmbiente ambiente)
        {
            var connectionFactory = _listaDeConnectionFactory.ContainsKey(ambiente.TipoDatabase) ?
                _listaDeConnectionFactory[ambiente.TipoDatabase] : throw new Exception(nameof(ambiente));
            return connectionFactory;
        }
    }
}