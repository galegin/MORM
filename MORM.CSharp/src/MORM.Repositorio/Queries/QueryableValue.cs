using MORM.CrossCutting;
using System.Configuration;

namespace MORM.Repositorio
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