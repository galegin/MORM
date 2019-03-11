using MORM.Utilidade.Atributos;
using MORM.Utilidade.Interfaces;
using MORM.Utilidade.Tipagens;
using System;
using System.Configuration;

namespace MORM.Utilidade.Entidades
{
    [Tabela("WEB_AMBIENTE")]
    public class Ambiente : IAmbiente
    {
        private static string _tipoDatabase = ConfigurationManager.AppSettings["tipoDatabase"] 
            ?? nameof(TipoDatabase.SqLite);

        public Ambiente()
        {
            Codigo = ConfigurationManager.AppSettings["ambiente"];
            TipoDatabase = (TipoDatabase)Enum.Parse(typeof(TipoDatabase), _tipoDatabase, false);
            ProviderName = ConfigurationManager.AppSettings["providerName"];
            Database = ConfigurationManager.AppSettings["database"];
            Username = ConfigurationManager.AppSettings["username"];
            Password = ConfigurationManager.AppSettings["password"];
            Hostname = ConfigurationManager.AppSettings["hostname"];
        }

        public Ambiente(string codigo, 
            TipoDatabase tipoDatabase, string providerName, 
            string database, string username, string password, string hostname)
        {
            Codigo = codigo;
            TipoDatabase = tipoDatabase; 
            ProviderName = providerName;
            Database = database;
            Username = username;
            Password = password;
            Hostname = hostname;
        }

        [Campo("CD_AMBIENTE", CampoTipo.Key)]
        public string Codigo { get; set; }
        public TipoDatabase TipoDatabase { get; set; }
        public string ProviderName { get; set; }
        [Campo("CD_DATABASE", CampoTipo.Req)]
        public string Database { get; set; }
        [Campo("CD_USERNAME", CampoTipo.Req)]
        public string Username { get; set; }
        [Campo("CD_PASSWORD", CampoTipo.Req)]
        public string Password { get; set; }
        public string Hostname { get; set; }
        [Campo("CD_EMPRESA", CampoTipo.Nul)]
        public int CodigoEmpresa { get; set; }
        [Campo("CD_USUARIO", CampoTipo.Nul)]
        public int CodigoUsuario { get; set; }
        public int CodigoTerminal { get; set; }
    }
}