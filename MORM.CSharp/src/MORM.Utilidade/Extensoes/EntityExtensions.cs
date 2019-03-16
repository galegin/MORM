using System;
using System.Linq;

namespace MORM.Utilidade.Extensoes
{
    public static class EntityExtensions
    {
        public static bool IsChavePreenchida(this object obj)
        {
            var campos = obj.GetType().GetCampos();
            var preenchido = campos.Any();

            foreach (var campo in campos)
            {
                if (campo.IsKey)
                {
                    var value = campo.OwnerProp.GetValue(obj);
                    if (value?.IsValueNull() != false)
                    {
                        preenchido = false;
                    }
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