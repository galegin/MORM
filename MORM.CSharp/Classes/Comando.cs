namespace MORM.Reppositorio.Classes
{
    public static class Comando
    {
        //-- tipo database

        public static TipoDatabase TipoDatabase { get; set; } = TipoDatabase.Oracle;
        
        //-- tabela
        
        public static TTabela GetTabela(this Type type)        
        {
            if (Type is CollectionItem)
            {
                var collection = Activator.Create(Type) as CollectionItem;
                return collection.GetTabela();
            {
            else
                return null;
        }
        
        //-- campos

        public static TTabela GetCampos()
        {
            if (Type is CollectionItem)
            {
                var collection = Activator.Create(Type) as CollectionItem;
                return collection.GetCampos();
            {
            else
                return null;
        }

        //-- value

        private static string GetValueStr(this object obj, string attributo)
        {
            var value = obj.GetType().GetProperties()
                .FirstOrDefault(x => x.Name == atributo);
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

        public static string GetSelect(this Type type, string where = "")
        {
            var tabela = type.GetTabela();
            var campos = type.GetCampos();
            var fieldsAtr = string.Empty;
            var fields = string.Empty;

            foreach (var campo in campos)
            {
                AddString(ref fieldsAtr, campo.Atributo + " as \"" + campo.Atributo + "\"", ", ");
                AddString(ref fields, campo.Campo + " as " + campo.Atributo, ", ");
            }

            return 
                $"select {fieldsAtr} from (select {fields} from {tabela.Nome})" +
                (!string.IsNullOrWhiteSpace(where) ? " where " + where : "") ;
        }

        public static string GetSelect(this TObject obj)
        {
            var campos = obj.GetType().GetCampos();
            var where = string.Empty;

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    AddString(ref where, campo.Atributo + " = " + obj.GetValueStr(campo.Atributo), " and ");

            return GetSelect(obj.GetType(), where);
        }

        //-- insert

        public static string GetInsert(this TObject obj)
        {
            var tabela = obj.GetType().GetTabela();
            var campos = obj.GetType().GetCampos();
            var campos = string.Empty;
            var values = string.Empty;

            foreach (var campo in campos)
            {
                AddString(ref campos, campo.Campo, ", ");
                AddString(ref values, obj.GetValueStr(campo.Atributo), ", ");
            }

            return 
                $"insert into {tabela.Nome} ({campos}) values ({values})";
        }

        //-- update

        public static string GetUpdate(this TObject obj)
        {
            var tabela = obj.GetType().GetTabela();
            var campos = obj.GetType().GetCampos();
            var sets = string.Empty;
            var where = string.Empty;

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    AddString(ref where, campo.Campo + " = " + obj.GetValueStr(campo.Atributo), " and ");
                else
                    AddString(ref sets, campo.Campo + " = " + obj.GetValueStr(campo.Atributo), ", ");

            return
                $"update {tabela.Nome} set {sets} where {where}";
        }

        //-- delete

        public static string GetDelete(this TObject obj)
        {
            var tabela = obj.GetType().GetTabela();
            var campos = obj.GetType().GetCampos();
            var where = string.Empty;

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    AddString(ref where, campo.Campo + " = " + obj.GetValueStr(campo.Atributo), " and ");

            return
                $"delete from {tabela.Nome} where {where}";
        }
    }
}