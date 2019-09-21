using MORM.Repositorio.Classes;
using MORM.Dominio.Types;
using System.Linq;

namespace MORM.Repositorio.Extensions
{
    public static class TipoDatabaseExtensions
    {
        public static ConnectionConfig GetConnectionConfig(this TipoDatabase tipoDatabase)
        {
            var listaConnectionConfig = 
                ConnectionConfigExtensions.GetListaConnectionConfig();

            return 
                listaConnectionConfig.FirstOrDefault(x => x.TipoDatabase == tipoDatabase) 
                ?? 
                new ConnectionConfig(tipoDatabase, string.Empty, string.Empty, string.Empty)
                ;
        }

        public static string GetNomeAssembly(this TipoDatabase tipoDatabase)
        {
            return tipoDatabase.GetConnectionConfig().NomeAssembly;
        }

        public static string GetNomeType(this TipoDatabase tipoDatabase)
        {
            return tipoDatabase.GetConnectionConfig().NomeType;
        }

        public static string GetConnectionString(this TipoDatabase tipoDatabase)
        {
            return tipoDatabase.GetConnectionConfig().ConnectionString;
        }
    }
}