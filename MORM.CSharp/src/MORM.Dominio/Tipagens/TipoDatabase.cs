using MORM.Dominio.Extensions;
using MORM.Infra.CrossCutting;
using System;
using System.Globalization;
using System.Linq;

namespace MORM.Dominio.Tipagens
{
    public enum TipoDatabase
    {
        Firebird,
        MySql,
        Oracle,
        PostgreSql,
        SqLite,
        SqlServer,
    }

    public static class TipoDatabaseExtension
    {
        //-- value

        public static string GetValueData(this TipoDatabase tipoDatabase, DateTime value)
        {
            switch (tipoDatabase)
            {
                case TipoDatabase.Firebird:
                    return "'" + value.ToString("dd.MM.yyyy HH:mm:ss") + "'";
                case TipoDatabase.Oracle:
                    return "to_date('" + value.ToString("dd/MM/yyyy HH:mm:ss") + "', 'DD/MM/YYYY HH24:MI:SS')";
                case TipoDatabase.MySql:
                case TipoDatabase.PostgreSql:
                    return "'" + value.ToString("yyyy/MM/dd HH:mm:ss") + "'";
                case TipoDatabase.SqLite:
                    return "'" + value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            return null;
        }

        public static string GetValueStr(this TipoDatabase tipoDatabase, object value)
        {
            value = value.GetValueNullable();

            return (
                value == null ? "null" :
                value is bool ? "'" + ((bool)value ? "T" : "F") + "'" :
                value is DateTime ? tipoDatabase.GetValueData((DateTime)value) :
                value is decimal ? ((decimal)value).ToString(CultureInfo.InvariantCulture) :
                value is double ? ((double)value).ToString(CultureInfo.InvariantCulture) :
                value is float ? ((float)value).ToString(CultureInfo.InvariantCulture) :
                value is long ? ((long)value).ToString() :
                value is int ? ((int)value).ToString() :
                value is short ? ((short)value).ToString() :
                value is string[] ? "'" + string.Join("|", value as string[]).Replace("'", "''") + "'" :
                value is string ? "'" + value.ToString().Replace("'", "''") + "'" : value.ToString());
        }

        public static string GetSqlTableExiste(this TipoDatabase tipo, string tablename)
        {
            switch (tipo)
            {
                case TipoDatabase.Firebird:
                    return $"select count(*) from RDB$RELATIONS where RDB$RELATION_NAME = '{tablename}'";
                default:
                case TipoDatabase.Oracle:
                    return $"select count(*) from USER_TABLES where TABLE_NAME = '{tablename}'";
            }
        }

        public static string GetSequenceGen(this TipoDatabase tipo, string tablename)
        {
            switch (tipo)
            {
                case TipoDatabase.Firebird:
                    return $"select GEN_ID(SQ_{tablename}, 0) from RDB$DATABASE";
                default:
                case TipoDatabase.Oracle:
                    return $"select SQ_{tablename}.NEXTVAL from DUAL";
            }
        }

        public static string GetSelectMax(this TipoDatabase tipo, string sql, string column)
        {
            return $"select coalesce(max({column}),0) + 1 as {column} from ({sql})";
        }

        public static string GetSelectLim(this TipoDatabase tipo, string sql, int qtde, int pagina = 0)
        {
            var regini = pagina * qtde;
            var regfin = regini + qtde;

            switch (tipo)
            {
                case TipoDatabase.Firebird:
                    return $"select firts {qtde} skip {regini} * from ({sql})";
                case TipoDatabase.MySql:
                case TipoDatabase.PostgreSql:
                    return $"select * from ({sql}) limit {regini}, {qtde}";
                default:
                case TipoDatabase.Oracle:
                    return
                        $"select * from ( " +
                        $"  select a.*, ROWNUM rnum from ({sql}) a " +
                        $"  where ROWNUM <= {regfin} " +
                        $") where rnum >= {regini} ";
                case TipoDatabase.SqLite:
                    return $"select * from ({sql}) limit {qtde} offset {regini}";
                case TipoDatabase.SqlServer:
                    return $"select * from ({sql}) offset {regini} rows fetch next {qtde} rows only ";
            }
        }

        /*
        SELECT * FROM (
          SELECT a.*, ROWNUM rnum FROM (
            SELECT * FROM tabela_enorme ORDER BY campo_indexado
          ) a WHERE ROWNUM <= 61200
        ) WHERE rnum >= 61000;
        */

        //-- table

        public static string GetCreateTable(this TipoDatabase tipo, string table, string[] fields, string[] keys)
        {
            var campos = fields.ToList();

            if (keys.Any())
                campos.Add(tipo.GetPrimaryKey(table, keys));

            return
                $"create table {table} ({string.Join(", ", campos)})";
        }

        public static string GetAlterTable(this TipoDatabase tipo, string table, string[] column)
        {
            switch (tipo)
            {
                case TipoDatabase.SqLite:
                    return $"alter table {table} add column {string.Join(" ", column)}";
                default:
                    return $"alter table {table} add {string.Join(" ", column)}";
            }

        }

        //-- primary

        public static string GetPrimaryKey(this TipoDatabase tipo, string table, string[] keys)
        {
            switch (tipo)
            {
                case TipoDatabase.SqLite:
                    return $"primary key ({string.Join(", ", keys)})";
                default:
                    return $"constraint pk_{table} primary key on ({string.Join(", ", keys)})";
            }
        }

        //-- foreign

        public static string GetDropForeignKey(this TipoDatabase tipo, string table, string tableRel)
        {
            switch (tipo)
            {
                case TipoDatabase.SqLite:
                    return string.Empty;
                default:
                    return $"alter table {table} drop constraint {table}_{tableRel}";
            }
        }

        public static string GetForeignKey(this TipoDatabase tipo, string table, string[] fields, 
            string tableRel, string[] fieldsRel)
        {
            switch (tipo)
            {
                case TipoDatabase.SqLite:
                    return string.Empty;
                default:
                    return $"alter table {table} add constraint {table}_{tableRel} foreign key ({string.Join(", ", fields)})" + 
                        $" references {tableRel} ({string.Join(", ", fieldsRel)})";
            }
        }

        //-- lista de comando

        public static string[] GetListaDeComando(this TipoDatabase tipo)
        {
            switch (tipo)
            {
                case TipoDatabase.Oracle:
                    return new[]
                    {
                      "ALTER SESSION SET NLS_LANGUAGE            = 'BRAZILIAN PORTUGUESE'",
                      "ALTER SESSION SET NLS_TERRITORY           = 'BRAZIL'",
                      "ALTER SESSION SET NLS_CURRENCY            = 'R$'",
                      "ALTER SESSION SET NLS_ISO_CURRENCY        = 'BRAZIL'",
                      "ALTER SESSION SET NLS_NUMERIC_CHARACTERS  = '.,'",
                      "ALTER SESSION SET NLS_CALENDAR            = 'GREGORIAN'",
                      "ALTER SESSION SET NLS_DATE_FORMAT         = 'DD/MM/RR HH24:MI:SS'",
                      "ALTER SESSION SET NLS_DATE_LANGUAGE       = 'BRAZILIAN PORTUGUESE'",
                      "ALTER SESSION SET NLS_TIME_FORMAT         = 'HH24:MI:SSXFF'",
                      "ALTER SESSION SET NLS_TIMESTAMP_FORMAT    = 'DD/MM/RR HH24:MI:SSXFF'",
                      "ALTER SESSION SET NLS_TIME_TZ_FORMAT      = 'HH24:MI:SSXFF TZR'",
                      "ALTER SESSION SET NLS_TIMESTAMP_TZ_FORMAT = 'DD/MM/RR HH24:MI:SSXFF TZR'",
                      "ALTER SESSION SET NLS_DUAL_CURRENCY       = 'Cr$'",
                      "ALTER SESSION SET NLS_COMP                = 'BINARY'",
                      "ALTER SESSION SET NLS_LENGTH_SEMANTICS    = 'BYTE'",
                      "ALTER SESSION SET NLS_NCHAR_CONV_EXCP     = 'FALSE'",
                    };
            }

            return null;
        }

        //-- parameter

        public static string GetNameParameter(this TipoDatabase tipo, string atributo)
        {
            switch (tipo)
            {
                case TipoDatabase.Oracle:
                    return $":{atributo}";
                default:
                    return $"@{atributo}";
            }
        }
    }
}