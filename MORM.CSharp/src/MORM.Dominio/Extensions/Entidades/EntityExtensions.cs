using System;
using System.Linq;

namespace MORM.Dominio.Extensions
{
    public static class EntityExtensions
    {
        public static bool IsChavePreenchida(this object obj)
        {
            var camposKey = obj.GetType().GetCampos().Where(x => x.IsKey);
            var preenchido = camposKey.Any();

            foreach (var campo in camposKey)
            {
                var value = campo.OwnerProp.GetValue(obj);
                if (value?.IsValueNull() != false)
                {
                    preenchido = false;
                }
            }

            return preenchido;
        }

        public static bool IsValueNull(this object value)
        {
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
    }
}