using System;

namespace MORM.Infra.CrossCutting
{
    public static class DataTypeExtension
    { 
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

        public static bool IsValueNull(this object value)
        {
            var tipoDado = value.GetType().GetTipoDadoModel();

            return (
                value == null ? true :
                tipoDado != null && value.Equals(tipoDado.ValorNulo) ? true :
                value is string[] ? ((string[])value).Length > 0 : true);
        }

        public static Type GetTypeNullable(this Type type)
        {
            var tipoDado = type.GetTipoDadoModel();
            return tipoDado?.Tipo ?? null;
        }

        public static object GetValueNull(this Type type)
        {
            var tipoDado = type.GetTipoDadoModel();
            return tipoDado?.ValorNulo ?? null;
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