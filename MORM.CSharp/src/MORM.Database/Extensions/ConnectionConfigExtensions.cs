using MORM.Database.Classes;
using MORM.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace MORM.Database.Extensions
{
    public static class ConnectionConfigExtensions
    {
        private static List<ConnectionConfig> _listaConnectionConfig;

        public static List<ConnectionConfig> GetListaConnectionConfig()
        {
            if (_listaConnectionConfig != null)
                return _listaConnectionConfig;

            var arquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "connectionconfig.json");
            _listaConnectionConfig = JsonExtensions.GetLista<ConnectionConfig>(arquivo, _connectionConfigPadrao.Replace("'", "\""));

            return _listaConnectionConfig;
        }

        #region padrao
        private const string _connectionConfigPadrao = @"[
    {
        'TipoDatabase':'Firebird',
        'NomeAssembly':'FirebirdSql.Data.FirebirdClient.dll',
        'NomeType':'FirebirdSql.Data.FirebirdClient.FbConnection',
        'ConnectionString':'User=SYSDBA;Password=masterkey;Database={database}\\{username}.fdb;DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0;'
    },
    {
        'TipoDatabase':'MySql',
        'NomeAssembly':'MySql.Data.dll',
        'NomeType':'MySql.Data.MySqlClient.MySqlConnection',
        'ConnectionString':'Server={hostname};Database={database};Uid={username};Pwd={password};'
    },
    {
        'TipoDatabase':'Oracle',
        'NomeAssembly':'Oracle.ManagedDataAccess.dll',
        'NomeType':'Oracle.ManagedDataAccess.Client.OracleConnection',
        'ConnectionString':'Data Source={database};User Id={username};Password={password};'
    },
    {
        'TipoDatabase':'PostgreSql',
        'NomeAssembly':'Npgsql.dll',
        'NomeType':'Npgsql.NpgsqlConnection',
        'ConnectionString':'User ID={username};Password={password};Host=localhost;Port=5432;Database={database};Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;'
    },
    {
        'TipoDatabase':'SqLite',
        'NomeAssembly':'System.Data.SQLite.dll',
        'NomeType':'System.Data.SQLite.SQLiteConnection',
        'ConnectionString':'Data Source={database}\\{username}.db;'
    },
    {
        'TipoDatabase':'SqlServer',
        'NomeAssembly':'System.Data.dll',
        'NomeType':'System.Data.SqlConnection',
        'ConnectionString':'Server={hostname};Database={database};User Id={username};Password={password};'
    }
]"; 
        #endregion
    }
}