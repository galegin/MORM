using MORM.CrossCutting;
using System;
using System.Data.Common;

namespace MORM.Dominio.Extensions
{
    public static class DataReaderExtensions
    {
        public static void SetValueFromDataReader(this object obj, DbDataReader dataReader)
        {
            obj.GetCampos().ForEach(campo =>
            {
                var index = dataReader.GetOrdinal(campo.Atributo);
                var type = campo.OwnerProp.PropertyType.GetTypeNullable();
                var value = dataReader.GetValueColumn(type, index);
                obj.SetInstancePropOrField(campo.Atributo, value);
            });
        }

        private static object GetValueColumn(this DbDataReader dataReader, Type type, int i)
        {
            var value = dataReader.GetValue(i);
            var tipoDado = type.GetTipoDadoModel();
            return dataReader.IsDBNull(i) ? null : 
                tipoDado?.ConvertDb.Invoke(value) ?? value;
        }
    }
}