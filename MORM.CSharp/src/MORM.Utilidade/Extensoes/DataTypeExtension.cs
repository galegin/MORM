using MORM.Utilidade.Atributos;
using MORM.Utilidade.Tipagens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Utilidade.Extensoes
{
    //-- galeg - 14/04/2018 14:13:29
    public static class DataTypeExtension
    {
        private static Type[] isBool = { typeof(bool), typeof(bool?) };
        private static Type[] isDate = { typeof(DateTime), typeof(DateTime?) };
        private static Type[] isReal = { typeof(decimal), typeof(decimal?), typeof(double), typeof(double?), typeof(float), typeof(float?) };
        private static Type[] isInt = { typeof(long), typeof(long?), typeof(int), typeof(int?), typeof(short), typeof(short?) };
        private static Type[] isStr = { typeof(string), typeof(string[]) };

        private static Dictionary<Type[], string> GetTypes(this TipoDatabase tipo)
        {
            switch (tipo)
            {
                default:
                case TipoDatabase.Firebird:
                case TipoDatabase.MySql:
                    return new Dictionary<Type[], string>
                    {
                        { isBool, "char(1)" },
                        { isDate, "timestamp" },
                        { isReal, "numeric{tam}" },
                        { isInt, "integer" },
                        { isStr, "varchar{tam}" },
                    };
                case TipoDatabase.Oracle:
                    return new Dictionary<Type[], string>
                    {
                        { isBool, "char(1)" },
                        { isDate, "date" },
                        { isReal, "number{tam}" },
                        { isInt, "integer" },
                        { isStr, "varchar{tam}" },
                    };
                case TipoDatabase.SqLite:
                    return new Dictionary<Type[], string>
                    {
                        { isBool, "text" },
                        { isDate, "text" },
                        { isReal, "real" },
                        { isInt, "integer" },
                        { isStr, "text" },
                    };
            }
        }

        public static string GetDataType(this TipoDatabase tipo, CampoAttribute campo)
        {
            var str = string.Empty;
            var types = tipo.GetTypes();

            if (isBool.Contains(campo.DataType))
                str = types[isBool];
            else if (isDate.Contains(campo.DataType))
                str = types[isDate];
            else if (isReal.Contains(campo.DataType))
                str = types[isReal];
            else if (isInt.Contains(campo.DataType))
                str = types[isInt];
            else if (isStr.Contains(campo.DataType))
                str = types[isStr];

            var tam = string.Empty;

            if (campo.Tamanho > 0)
            {
                tam += "(" + campo.Tamanho;
                if (campo.Precisao > 0)
                    tam += "," + campo.Precisao;
                tam += ")";
            }

            return str.Replace("{tam}", tam);
        }

        public static object GetValueNullable(this object value)
        {
            if (value is bool?) return (value as bool?).Value;
            else if (value is DateTime?) return (value as DateTime?).Value;
            else if (value is decimal?) return (value as decimal?).Value;
            else if (value is double?) return (value as double?).Value;
            else if (value is float?) return (value as float?).Value;
            else if (value is long?) return (value as long?).Value;
            else if (value is int?) return (value as int?).Value;
            else if (value is short?) return (value as short?).Value;
            else return value;
        }

        public static Type GetTypeNullable(this object value)
        {
            var type = value.GetType();
            if (type == typeof(Nullable))
                type = type.GetGenericArguments()[0];
            return type;
        }

        public static bool IsNullable(this object value)
        {
            return (value.GetType() == typeof(Nullable));
        }
    }
}