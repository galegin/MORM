using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    #region enum
    public enum TipoDado
    {
        Bool,
        Date,
        Real,
        Int,
        Str,
        Lst,
        Obj,
        Enum
    }
    #endregion

    #region class
    public class TipoDadoModel
    {
        #region propriedades
        public TipoDado Dado { get; set; }
        public Type[] Tipo { get; set; }
        public object[] Valor { get; set; }
        public Func<object, object> Convert { get; set; }
        public Func<object, object> ConvertDb { get; set; }
        public Func<object, string> ConvertStr { get; set; }
        #endregion

        #region constutores
        public TipoDadoModel(TipoDado dado, Type[] tipo, object[] valor, 
            Func<object, object> convert, 
            Func<object, object> convertDb, 
            Func<object, string> convertStr)
        {
            Dado = dado;
            Tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            Valor = valor ?? throw new ArgumentNullException(nameof(valor));
            Convert = convert;
            ConvertDb = convertDb;
            ConvertStr = convertStr;
        }
        #endregion

        #region metodos
        public Type GetTipo() => Tipo[0];
        public object GetNulo() => Valor[1];
        public bool IsNulo(object value) => 
            value == null || Valor.Contains(value);
        #endregion
    }
    #endregion

    #region extensions
    public static class TipoDadoExtensions
    {
        #region metodos
        private static List<TipoDadoModel> ListaDeTipo = new List<TipoDadoModel>
        {
            #region bool
            new TipoDadoModel(TipoDado.Bool, 
                new[]{ typeof(bool), typeof(bool?) }, new object[] { false, false }, 
                (value) => (value as bool?).Value, 
                (value) => ".1.S.SIM.T.TRUE.".Contains(Convert.ToString(value)),
                (value) => "'" + ((bool) value ? "T" : "F") + "'"),
            #endregion
            #region date
            new TipoDadoModel(TipoDado.Date, 
                new[]{ typeof(DateTime), typeof(DateTime?) }, new object[]{ DateTime.MinValue, DateTime.MinValue }, 
                (value) => (value as DateTime?).Value, 
                (value) => Convert.ToDateTime(value),
                (value) => ((DateTime) value).ToString(CultureInfo.InvariantCulture)),
            #endregion
            #region real
            new TipoDadoModel(TipoDado.Real, 
                new[]{ typeof(decimal), typeof(decimal?) }, new object[]{ decimal.MinValue, 0M },
                (value) => (value as decimal?).Value, 
                (value) => Convert.ToDecimal(value),
                (value) => ((decimal) value).ToString(CultureInfo.InvariantCulture)),
            new TipoDadoModel(TipoDado.Real, 
                new[]{ typeof(double), typeof(double?) }, new object[]{ double.MinValue, 0D },
                (value) => (value as double?).Value, 
                (value) => Convert.ToDouble(value),
                (value) => ((double) value).ToString(CultureInfo.InvariantCulture)),
            new TipoDadoModel(TipoDado.Real, 
                new[]{ typeof(float), typeof(float?) }, new object[]{ float.MinValue, 0F },
                (value) => (value as float?).Value, 
                (value) => Convert.ToSingle(value),
                (value) => ((float) value).ToString(CultureInfo.InvariantCulture)),
            #endregion
            #region int
            new TipoDadoModel(TipoDado.Int, 
                new[]{ typeof(long), typeof(long?) }, new object[]{ long.MinValue, 0L },
                (value) => (value as long?).Value, 
                (value) => Convert.ToInt64(value),
                (value) => ((long) value).ToString()),
            new TipoDadoModel(TipoDado.Int, 
                new[]{ typeof(int), typeof(int?) }, new object[]{ int.MinValue, 0 },
                (value) => (value as int?).Value, 
                (value) => Convert.ToInt32(value),
                (value) => ((int) value).ToString()),
            new TipoDadoModel(TipoDado.Int, 
                new[]{ typeof(short), typeof(short?) }, new object[]{ int.MinValue, (short)0 },
                (value) => (value as short?).Value, 
                (value) => Convert.ToInt16(value),
                (value) => ((short) value).ToString()),
            #endregion
            #region str
            new TipoDadoModel(TipoDado.Str, 
                new[]{ typeof(string), typeof(string) }, new object[]{ null, null },
                (value) => (value as string), 
                (value) => Convert.ToString(value),
                (value) => "'" + value.ToString().Replace("'", "''") + "'"),
            #endregion
            #region obj
            new TipoDadoModel(TipoDado.Obj,
                new[]{ typeof(object), typeof(object) }, new object[]{ null, null },
                (value) => (value as object), 
                (value) => null,
                (value) => null),
            #endregion
            #region lst
            new TipoDadoModel(TipoDado.Lst,
                new[]{ typeof(string[]), typeof(string[]) }, new object[]{ null, null },
                (value) => (value as string[]),
                (value) => Convert.ToString(value).Split('\n'),
                (value) => "'" + string.Join("\n", value as string[]).Replace("'", "''") + "'"),
            #endregion
            #region enum
            new TipoDadoModel(TipoDado.Enum,
                new[]{ typeof(Enum), typeof(Enum) }, new object[]{ null, null },
                (value) => (value as Enum),
                (value) => Convert.ToInt32(value),
                (value) => ((int) value).ToString()),
            #endregion
        };

        public static TipoDadoModel GetTipoDadoModel(this Type type)
        {
            if (type.IsEnum)
                type = typeof(Enum);
            //else if (type.IsClass)
            //    type = typeof(object);
            return ListaDeTipo.FirstOrDefault(x => x.Tipo.Contains(type));
        }

        public static TipoDadoModel GetTipoDadoModel(this PropertyInfo prop)
        {
            return prop.PropertyType.GetTipoDadoModel();
        }
        #endregion
    }
    #endregion
}