using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using MORM.Utilidade.Tipagens;
using MORM.Utilidade.Atributos;
using MORM.Utilidade.Extensoes;
using MORM.Repositorio.Interfaces;

namespace MORM.Repositorio.Context
{
    public class Comando : IComando
    {
        public Comando(TipoDatabase tipoDatabase)
        {
            TipoDatabase = tipoDatabase;
        }
        
        //-- tipo database

        public TipoDatabase TipoDatabase { get; }

        //-- value

        public string GetValueStr(object value)
        {
            value = value.GetValueNullable();

            return (
                value == null ? "null" :
                value is bool ? "'" + ((bool)value ? "T" : "F") + "'" :
                value is DateTime ? TipoDatabase.GetValueData((DateTime)value) :
                value is decimal ? ((decimal)value).ToString(CultureInfo.InvariantCulture) :
                value is double ? ((double)value).ToString(CultureInfo.InvariantCulture) :
                value is float ? ((float)value).ToString(CultureInfo.InvariantCulture) :
                value is long ? ((long)value).ToString() :
                value is int ? ((int)value).ToString() :
                value is short ? ((short)value).ToString() :
                value is string[] ? "'" + string.Join("|", value as string[]).Replace("'", "''") + "'" :
                value is string ? "'" + value.ToString().Replace("'", "''") + "'" : value.ToString());
        }

        public string GetValueStr(object obj, string atributo)
        {
            var value = obj.GetType().GetProperties()
                .FirstOrDefault(x => x.Name == atributo)
                .GetValue(obj);

            return GetValueStr(value);
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
                value is decimal ? (((decimal)value) == decimal.MinValue) :
                value is double ? (((double)value) == double.MinValue) :
                value is float ? (((float)value) == double.MinValue) :
                value is long ? (((long)value) == long.MinValue) :
                value is int ? (((int)value) == int.MinValue) :
                value is short ? (((short)value) == short.MinValue) :
                value is string[] ? ((string[])value).Length > 0 :
                value is string ? (value.ToString() == "") : true);
        }
        
        //-- where

        public string GetWhereKey(object obj)
        {
            var campos = obj.GetType().GetCampos();
            var wheres = new List<string>();

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    wheres.Add(campo.Atributo + " = " + GetValueStr(obj, campo.Atributo));

            return 
                wheres.Any() ? string.Join(" and ", wheres) : string.Empty;
        }

        public string GetWhereAll(object obj)
        {
            var campos = obj.GetType().GetCampos();
            var wheres = new List<string>();

            foreach (var campo in campos)
                if (!IsValueNull(obj, campo.Atributo))
                    wheres.Add(campo.Atributo + " = " + GetValueStr(obj, campo.Atributo));

            return 
                wheres.Any() ? string.Join(" and ", wheres) : string.Empty;
        }

        public string GetWhereObj<TObject>(object obj, CampoTipo[] campoTipo)
        {
            var campos = typeof(TObject).GetCampos().Where(x => campoTipo.Contains(x.Tipo));
            var where = new List<string>();

            var isKeyOnly = campoTipo.Length == 1 && campoTipo.Contains(CampoTipo.Key);

            foreach (var campo in campos)
            {
                var valueObj = campo.OwnerProp.GetValue(obj);
                if (isKeyOnly || (!isKeyOnly && valueObj != null))
                    where.Add($"{campo.Atributo} = {GetValueStr(valueObj)}");
            }

            return string.Join(" and ", where);
        }

        //-- select

        public string GetSelect(Type type, string where = null, int qtde = -1, int pagina = 0)
        {
            var tabela = type.GetTabela();
            var campos = type.GetCampos();
            var fieldsAtr = new List<string>();
            var fields = new List<string>();

            foreach (var campo in campos)
            {
                fieldsAtr.Add(campo.Atributo + " as \"" + campo.Atributo + "\"");
                fields.Add(campo.Nome + " as " + campo.Atributo);
            }

            var sql = 
                "select " + string.Join(", ", fieldsAtr) + 
                " from (select " + string.Join(", ", fields) + " from " + tabela.Nome + ")" +
                (!string.IsNullOrWhiteSpace(where) ? " where " + where : string.Empty);

            if (qtde != -1)
            {
                sql = TipoDatabase.GetSelectLim(sql, qtde, pagina);
            }

            return sql;
        }

        public string GetSelect(object obj)
        {
            return GetSelect(obj.GetType(), GetWhereKey(obj));
        }

        //-- insert

        public string GetInsert(object obj)
        {
            var tabela = obj.GetType().GetTabela();
            var campos = obj.GetType().GetCampos();
            var fields = new List<string>();
            var values = new List<string>();

            foreach (var campo in campos)
            {
                fields.Add(campo.Nome);
                values.Add(GetValueStr(obj, campo.Atributo));
            }

            return 
                "insert into " + tabela.Nome + 
                " (" + string.Join(", ", fields) + 
                ") values (" + string.Join(", ", values) + 
                ")";
        }

        //-- update

        public string GetUpdate(object obj)
        {
            var tabela = obj.GetType().GetTabela();
            var campos = obj.GetType().GetCampos();
            var sets = new List<string>();
            var wheres = new List<string>();

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    wheres.Add(campo.Nome + " = " + GetValueStr(obj, campo.Atributo));
                else
                    sets.Add(campo.Nome + " = " + GetValueStr(obj, campo.Atributo));

            return
                "update " + tabela.Nome + 
                " set " + string.Join(", ", sets) + 
                " where " + string.Join(" and ", wheres);
        }

        //-- delete

        public string GetDelete(object obj)
        {
            var tabela = obj.GetType().GetTabela();
            var campos = obj.GetType().GetCampos();
            var wheres = new List<string>();

            foreach (var campo in campos)
                if (campo.Tipo == CampoTipo.Key)
                    wheres.Add(campo.Nome + " = " + GetValueStr(obj, campo.Atributo));

            return
                "delete from " + tabela.Nome + 
                " where " + string.Join(" and ", wheres);
        }

        public string GetSequenciaGen(Type type)
        {
            var table = type.GetTabela().Nome;
            return TipoDatabase.GetSequenceGen(table);
        }

        public string GetSequenciaMax(Type type, string where)
        {
            var table = type.GetTabela().Nome;
            var fieldsAtr = new List<string>();
            var fields = new List<string>();

            PropertyInfo campoSelectMax = null;

            foreach (var prop in type.GetProperties())
            {
                var selectMax = prop.GetSelectMax();
                if (selectMax != null)
                {
                    campoSelectMax = prop;
                    break;
                }
            }

            if (campoSelectMax == null)
                throw new Exception("Campo SelectMax deve ser configurado");

            var sql = GetSelect(type, where);

            return
                TipoDatabase.GetSelectMax(sql, $"\"{campoSelectMax.Name}\"");
        }
    }
}