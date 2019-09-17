using MORM.Dominio.Interfaces;
using MORM.Dominio.Tipagens;
using System.Configuration;

namespace MORM.Repositorio.Queries
{
    public class QueryableValue : IQueryableValue
    {
        private readonly TipoDatabase _tipoDatabase;

        public QueryableValue()
        {
            var tipoDatabaseStr = ConfigurationManager.AppSettings["tipoDatabase"] ?? string.Empty;
            _tipoDatabase = tipoDatabaseStr.GetTipoDatabase();
        }

        public string GetString(object value)
        {
            return _tipoDatabase.GetValueStr(value);
        }
    }
}