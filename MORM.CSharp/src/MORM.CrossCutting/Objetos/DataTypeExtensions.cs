using System;

namespace MORM.CrossCutting
{
    public static class DataTypeExtensions
    { 
        public static object GetValueNullable(this object value)
        {
            var tipoDado = value?.GetType().GetTipoDadoModel();
            return tipoDado?.Convert?.Invoke(value) ?? null;
        }

        public static bool IsValueNull(this object value)
        {
            var tipoDado = value?.GetType().GetTipoDadoModel();
            return tipoDado?.IsNulo(value) ?? true;
        }

        public static Type GetTypeNullable(this Type type)
        {
            var tipoDado = type.GetTipoDadoModel();
            return tipoDado?.GetTipo() ?? null;
        }

        public static object GetValueNull(this Type type)
        {
            var tipoDado = type.GetTipoDadoModel();
            return tipoDado?.GetNulo() ?? null;
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