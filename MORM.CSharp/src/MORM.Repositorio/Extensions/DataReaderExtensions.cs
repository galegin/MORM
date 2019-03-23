using MORM.Dominio.Extensoes;
using System;
using System.Data.Common;

namespace MORM.Repositorio.Extensions
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
            return 
                dataReader.IsDBNull(i) ? null :
                type == typeof(bool) ? ".1.S.SIM.T.TRUE.".Contains(Convert.ToString(dataReader.GetValue(i))) :
                type == typeof(DateTime) ? Convert.ToDateTime(dataReader.GetValue(i)) :
                type == typeof(decimal) ? Convert.ToDecimal(dataReader.GetValue(i)) :
                type == typeof(double) ? Convert.ToDouble(dataReader.GetValue(i)) :
                type == typeof(float) ? Convert.ToSingle(dataReader.GetValue(i)) :
                type == typeof(long) ? Convert.ToInt64(dataReader.GetValue(i)) :
                type == typeof(int) ? Convert.ToInt32(dataReader.GetValue(i)) :
                type == typeof(short) ? Convert.ToInt16(dataReader.GetValue(i)) :
                type == typeof(string[]) ? Convert.ToString(dataReader.GetValue(i)).Split('|') :
                type == typeof(string) ? Convert.ToString(dataReader.GetValue(i)) : dataReader.GetValue(i);
        }
    }
}