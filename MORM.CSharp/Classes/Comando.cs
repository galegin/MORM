namespace MORM.Reppositorio.Classes
{
    public static class Comando
    {
        //-- tipo database

        public static TipoDatabase TipoDatabase { get; set; } = TipoDatabase.Oracle;

        //-- value

        private static string GetValueStr(this object value)
        {
            return (
                value == null ? "null" :
                value.GetType() == typeof(bool) ? "'" + ((bool)value ? "T" : "F") + "'" :
                value.GetType() == typeof(DateTime) ? TipoDatabase.GetValueData((DateTime)value) :
                value.GetType() == typeof(decimal) ? value.ToString().Replace(",", ".") :
                value.GetType() == typeof(double) ? value.ToString().Replace(",", ".") :
                value.GetType() == typeof(int) ? value.ToString() :
                value.GetType() == typeof(string) ? "'" + value.ToString().Replace("'", "''") + "'" : value.ToString());
        }

        //-- string

        public static void AddString(ref string str, string val, string seq, string ini = "")
        {
            str += (!string.IsNullOrWhiteSpace(str) ? sep : ini) + val;
        }

        //-- select

        public static string GetSelect(this Type type, string where = "", string order = "")
        {
            var table = typeof(type).GetAttributeType<TabelaAttribute>().Nome;
            var fieldsAtr = string.Empty;
            var fields = string.Empty;

            foreach (var prop in typeof(type).GetProperties())
            {
                var campo = prop.GetAttributeProp<CampoAttribute>();
                if (campo != null)
                {
                    AddString(ref fieldsAtr, prop.Name + " as \"" + prop.Name + "\"", ", ");
                    AddString(ref fields, campo.Nome + " as " + prop.Name, ", ");
                }
            }

            return $"select {fieldsAtr} from (select {fields} from {table})" +
                (!string.IsNullOrWhiteSpace(where) ? " where " + where : "") +
                (!string.IsNullOrWhiteSpace(order) ? " order by " + order : ""); ;
        }

        public static string GetSelect(this TObject obj)
        {
            var where = string.Empty;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var campo = prop.GetAttributeProp<CampoAttribute>();
                if (campo != null && campo.IsKey)
                    AddString(ref where, prop.Name + " = " + prop.GetValue(obj, null).GetValueStr(), " and ");
            }

            return GetSelect(obj.GetType(), where);
        }

        //-- insert

        public static string GetInsert(this TObject obj)
        {
            var table = obj.GetType().GetAttributeType<TabelaAttribute>().Nome;
            var campos = string.Empty;
            var values = string.Empty;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var campo = prop.GetAttributeProp<CampoAttribute>();
                if (campo != null)
                {
                    AddString(ref campos, campo.Nome, ", ");
                    AddString(ref values, prop.GetValue(obj, null).GetValueStr(), ", ");
                }
            }

            return $"insert into {table} ({campos}) values ({values})";
        }

        //-- update

        public static string GetUpdate(this TObject obj)
        {
            var table = obj.GetType().GetAttributeType<TabelaAttribute>().Nome;
            var sets = string.Empty;
            var where = string.Empty;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var campo = prop.GetAttributeProp<CampoAttribute>();
                if (campo != null)
                {
                    if (campo.IsKey)
                        AddString(ref where, campo.Nome + " = " + prop.GetValue(obj, null).GetValueStr(), " and ");
                    else
                        AddString(ref sets, campo.Nome + " = " + prop.GetValue(obj, null).GetValueStr(), ", ");
                }
            }

            return $"update {table} set {sets} where {where}";
        }

        //-- delete

        public static string GetDelete(this TObject obj)
        {
            var table = obj.GetType().GetAttributeType<TabelaAttribute>().Nome;
            var where = string.Empty;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var campo = prop.GetAttributeProp<CampoAttribute>();
                if (campo != null && campo.IsKey)
                    AddString(ref where, campo.Nome + " = " + prop.GetValue(obj, null).GetValueStr(), " and ");
            }

            return $"delete from {table} where {where}";
        }
    }
}