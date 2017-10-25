using System;

namespace MORM.Data.Classes
{
    public enum TipoDatabase
    {
        Firebird,
        Oracle,
        MySql
    }
    
    public static class TipoDatabaseExtension
    {
        public static string GetValueData(this TipoDatabase tipoDatabase, DateTime dateTime)
        {
            switch (tipoDatabase)
            {
                case TipoDatabase.Firebird:
                    return "'" + dateTime.ToString("dd.MM.yyyy HH:mm:ss") + "'";
                case TipoDatabase.Oracle:
                    return "to_date('" + dateTime.ToString("dd/MM/yyyy HH:mm:ss") + "', 'DD/MM/YYYY HH24:MI:SS')";
                case TipoDatabase.MySql:
                    return "'" + dateTime.ToString("yyyy/MM/dd HH:mm:ss") + "'";
            }
            
            return null;
        }
    }
}