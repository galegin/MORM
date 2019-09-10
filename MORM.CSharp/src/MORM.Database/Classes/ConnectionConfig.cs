using MORM.Dominio.Tipagens;
using System;

namespace MORM.Repositorio.Classes
{
    public class ConnectionConfig
    {
        public ConnectionConfig() { }

        public ConnectionConfig(TipoDatabase tipoDatabase, string nomeAssembly, string nomeType, string connectionString)
        {
            TipoDatabase = tipoDatabase;
            NomeAssembly = nomeAssembly ?? throw new ArgumentNullException(nameof(nomeAssembly));
            NomeType = nomeType ?? throw new ArgumentNullException(nameof(nomeType));
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public TipoDatabase TipoDatabase { get; set; }
        public string NomeAssembly { get; set; }
        public string NomeType { get; set; }
        public string ConnectionString { get; set; }
    }
}