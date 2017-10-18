using System;
using System.Linq;

namespace MORM.CSharp.Classes
{
    public static class Comando
    {
        //-- tipo database

        public static TipoDatabase TipoDatabase { get; set; } //= TipoDatabase.Oracle;
        
        //-- tabela
        
        public static Tabela GetTabela(this Type type)        
        {
        	if (type == typeof(CollectionItem))
            {
                var collection = Activator.CreateInstance(type) as CollectionItem;
                return collection.GetTabela();
            }
            else
                return null;
        }
        
        //-- campos

        public static Campos GetCampos(this Type type)
        {
        	if (type == typeof(CollectionItem))
            {
                var collection = Activator.CreateInstance(type) as CollectionItem;
                return collection.GetCampos();
            }
            else
                return null;
        }

        //-- value

        private static string GetValueStr(this object obj, string atributo)
        {
            var value = obj.GetType().GetProperties()
            	.FirstOrDefault(x => x.Name == atributo)
            	.GetValue(obj);
            
            return (
                value == null ? "null" :
            	value is bool ? "'" + ((bool)value ? "T" : "F") + "'" :
            	value is DateTime ? TipoDatabase.GetValueData((DateTime)value) :
            	value is decimal ? value.ToString().Replace(",", ".") :
            	value is double ? value.ToString().Replace(",", ".") :
            	value is int ? value.ToString() :
            	value is string ? "'" + value.ToString().Replace("'", "''") + "'" : value.ToString());
        }

        //-- string

        public static void AddString(ref string str, string val, string sep, string ini = "")
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
                AddString(ref fields, campo.Nome + " as " + campo.Atributo, ", ");
            }

            return 
                "select " + fieldsAtr + 
            	" from (select " + fields + " from " + tabela.Nome + ")" +
                (!string.IsNullOrWhiteSpace(where) ? " where " + where : "") ;
        }

        public static string GetSelect(this object obj)
        {
            var campos = obj.GetType().GetCampos();
            var where = string.Empty;

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    AddString(ref where, campo.Atributo + " = " + obj.GetValueStr(campo.Atributo), " and ");

            return GetSelect(obj.GetType(), where);
        }

        //-- insert

        public static string GetInsert(this object obj)
        {
            var tabela = obj.GetType().GetTabela();
            var campos = obj.GetType().GetCampos();
            var fields = string.Empty;
            var values = string.Empty;

            foreach (var campo in campos)
            {
                AddString(ref fields, campo.Nome, ", ");
                AddString(ref values, obj.GetValueStr(campo.Atributo), ", ");
            }

            return 
                "insert into " + tabela.Nome + 
            	" (" + fields + 
            	") values (" + values + ")";
        }

        //-- update

        public static string GetUpdate(this object obj)
        {
            var tabela = obj.GetType().GetTabela();
            var campos = obj.GetType().GetCampos();
            var sets = string.Empty;
            var where = string.Empty;

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    AddString(ref where, campo.Nome + " = " + obj.GetValueStr(campo.Atributo), " and ");
                else
                    AddString(ref sets, campo.Nome + " = " + obj.GetValueStr(campo.Atributo), ", ");

            return
                "update " + tabela.Nome + 
            	" set " + sets + 
            	" where " + where;
        }

        //-- delete

        public static string GetDelete(this object obj)
        {
            var tabela = obj.GetType().GetTabela();
            var campos = obj.GetType().GetCampos();
            var where = string.Empty;

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    AddString(ref where, campo.Nome + " = " + obj.GetValueStr(campo.Atributo), " and ");

            return
                "delete from " + tabela.Nome + 
            	" where " + where;
        }
    }
}