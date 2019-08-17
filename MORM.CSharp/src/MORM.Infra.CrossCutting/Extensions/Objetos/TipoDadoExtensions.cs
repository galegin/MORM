using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Infra.CrossCutting
{
    public enum TipoDadoEnum
    {
        Bool,
        Date,
        Real,
        Int,
        Str
    }

    public class TipoDadoModel
    {
        public TipoDadoModel(TipoDadoEnum tipoDado, Type tipo, Type tipoNulo, object valor, object valorNulo)
        {
            TipoDado = tipoDado;
            Tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            TipoNulo = tipoNulo ?? throw new ArgumentNullException(nameof(tipoNulo));
            Valor = valor ?? throw new ArgumentNullException(nameof(valor));
            ValorNulo = valorNulo ?? throw new ArgumentNullException(nameof(valorNulo));
        }

        public TipoDadoEnum TipoDado { get; set; }
        public Type Tipo { get; set; }
        public Type TipoNulo { get; set; }
        public object Valor { get; set; }
        public object ValorNulo { get; set; }
    }

    public static class TipoDadoExtensions
    {
        private static List<TipoDadoModel> ListaDeTipo = new List<TipoDadoModel>
        {
            new TipoDadoModel(TipoDadoEnum.Bool, typeof(bool), typeof(bool?), false, false),
            new TipoDadoModel(TipoDadoEnum.Date, typeof(DateTime), typeof(DateTime?), DateTime.MinValue, DateTime.MinValue),
            new TipoDadoModel(TipoDadoEnum.Real, typeof(decimal), typeof(decimal?), decimal.MinValue, 0M),
            new TipoDadoModel(TipoDadoEnum.Real, typeof(double), typeof(double?), double.MinValue, 0D),
            new TipoDadoModel(TipoDadoEnum.Real, typeof(float), typeof(float?), float.MinValue, 0F),
            new TipoDadoModel(TipoDadoEnum.Int, typeof(long), typeof(long?), long.MinValue, 0L),
            new TipoDadoModel(TipoDadoEnum.Int, typeof(int), typeof(int?), int.MinValue, 0),
            new TipoDadoModel(TipoDadoEnum.Int, typeof(short), typeof(short?), int.MinValue, (short)0),
            new TipoDadoModel(TipoDadoEnum.Str, typeof(string), typeof(string), string.Empty, string.Empty),
        };

        public static TipoDadoModel GetTipoDadoModel(this Type type)
        {
            return ListaDeTipo.FirstOrDefault(x => x.Tipo == type || x.TipoNulo == type);
        }
    }
}