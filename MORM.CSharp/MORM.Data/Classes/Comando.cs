using System;
using System.Linq;
using MORM.Util.Classes;

namespace MORM.Data.Classes
{
    public class Comando
    {
        public Comando(TipoDatabase tipoDatabase)
        {
            TipoDatabase = tipoDatabase;
        }
        
        //-- tipo database

        public TipoDatabase TipoDatabase { get; private set; }
        
        //-- tabela
        
        public Tabela GetTabela(Type type)        
        {
        	if (type.GetType().IsInstanceOfType(typeof(CollectionItem)))
            {
                var collection = Activator.CreateInstance(type) as CollectionItem;
                return collection.GetTabela();
            }
            else
                return null;
        }
        
        //-- campos

        public Campos GetCampos(Type type)
        {
        	if (type.GetType().IsInstanceOfType(typeof(CollectionItem)))
            {
                var collection = Activator.CreateInstance(type) as CollectionItem;
                return collection.GetCampos();
            }
            else
                return null;
        }

        //-- value

        public string GetValueStr(object obj, string atributo)
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

        private bool IsValueNull(object obj, string atributo)
        {
            var value = obj.GetType().GetProperties()
            	.FirstOrDefault(x => x.Name == atributo)
            	.GetValue(obj);
            
            return (
                value == null ? true :
            	value is bool ? (!((bool)value)) :
            	value is DateTime ? (((DateTime)value) == DateTime.MinValue) :
            	value is decimal ? (((decimal)value) == 0) :
            	value is double ? (((double)value) == 0) :
            	value is int ? (((int)value) == 0) :
            	value is string ? (value.ToString() == "") : true);
        }

        //-- string

        public void AddString(ref string str, string val, string sep, string ini = "")
        {
            str += (!string.IsNullOrWhiteSpace(str) ? sep : ini) + val;
        }
        
        //-- where

        public string GetWhereKey(object obj)
        {
            var campos = GetCampos(obj.GetType());
            var where = string.Empty;

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    AddString(ref where, campo.Atributo + " = " + GetValueStr(obj, campo.Atributo), " and ");

            return where;
        }

        public string GetWhereAll(object obj)
        {
            var campos = GetCampos(obj.GetType());
            var where = string.Empty;

            foreach (var campo in campos)
                if (!IsValueNull(obj, campo.Atributo))
                    AddString(ref where, campo.Atributo + " = " + GetValueStr(obj, campo.Atributo), " and ");

            return where;
        }

        //-- select

        public string GetSelect(Type type, string where = "")
        {
            var tabela = GetTabela(type);
            var campos = GetCampos(type);
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

        public string GetSelect(object obj)
        {
            return GetSelect(obj.GetType(), GetWhereKey(obj));
        }

        //-- insert

        public string GetInsert(object obj)
        {
            var tabela = GetTabela(obj.GetType());
            var campos = GetCampos(obj.GetType());
            var fields = string.Empty;
            var values = string.Empty;

            foreach (var campo in campos)
            {
                AddString(ref fields, campo.Nome, ", ");
                AddString(ref values, GetValueStr(obj, campo.Atributo), ", ");
            }

            return 
                "insert into " + tabela.Nome + 
            	" (" + fields + 
            	") values (" + values + ")";
        }

        //-- update

        public string GetUpdate(object obj)
        {
            var tabela = GetTabela(obj.GetType());
            var campos = GetCampos(obj.GetType());
            var sets = string.Empty;
            var where = string.Empty;

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    AddString(ref where, campo.Nome + " = " + GetValueStr(obj, campo.Atributo), " and ");
                else
                    AddString(ref sets, campo.Nome + " = " + GetValueStr(obj, campo.Atributo), ", ");

            return
                "update " + tabela.Nome + 
            	" set " + sets + 
            	" where " + where;
        }

        //-- delete

        public string GetDelete(object obj)
        {
            var tabela = GetTabela(obj.GetType());
            var campos = GetCampos(obj.GetType());
            var where = string.Empty;

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    AddString(ref where, campo.Nome + " = " + GetValueStr(obj, campo.Atributo), " and ");

            return
                "delete from " + tabela.Nome + 
            	" where " + where;
        }
    }
}