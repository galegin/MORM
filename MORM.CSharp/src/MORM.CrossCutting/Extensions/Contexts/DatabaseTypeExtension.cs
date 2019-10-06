using System.Collections.Generic;

namespace MORM.CrossCutting
{
    public static class DatabaseTypeExtensions
    {
        private static Dictionary<TipoDado, string> GetTypes(this TipoDatabase tipo)
        {
            switch (tipo)
            {
                default:
                case TipoDatabase.Firebird:
                case TipoDatabase.MySql:
                case TipoDatabase.PostgreSql:
                    return new Dictionary<TipoDado, string>
                    {
                        { TipoDado.Bool, "char(1)" },
                        { TipoDado.Date, "timestamp" },
                        { TipoDado.Real, "numeric{tam}" },
                        { TipoDado.Int, "integer" },
                        { TipoDado.Str, "varchar{tam}" },
                    };
                case TipoDatabase.Oracle:
                    return new Dictionary<TipoDado, string>
                    {
                        { TipoDado.Bool, "char(1)" },
                        { TipoDado.Date, "date" },
                        { TipoDado.Real, "number{tam}" },
                        { TipoDado.Int, "integer" },
                        { TipoDado.Str, "varchar{tam}" },
                    };
                case TipoDatabase.SqLite:
                    return new Dictionary<TipoDado, string>
                    {
                        { TipoDado.Bool, "text" },
                        { TipoDado.Date, "text" },
                        { TipoDado.Real, "real" },
                        { TipoDado.Int, "integer" },
                        { TipoDado.Str, "text" },
                    };
            }
        }

        public static string GetDataType(this TipoDatabase tipo, CampoAttribute campo)
        {
            var types = tipo.GetTypes();
            var tipoDado = campo.DataType.GetTipoDadoModel();
            var str = types.ContainsKey(tipoDado.Dado) ? types[tipoDado.Dado] : null;
            if (str == null)
                return null;

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
    }
}