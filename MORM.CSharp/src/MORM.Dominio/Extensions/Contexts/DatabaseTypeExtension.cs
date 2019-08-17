using MORM.Dominio.Atributos;
using MORM.Dominio.Tipagens;
using System.Collections.Generic;
using MORM.Infra.CrossCutting;

namespace MORM.Dominio.Extensions
{
    public static class DatabaseTypeExtensions
    {
        private static Dictionary<TipoDadoEnum, string> GetTypes(this TipoDatabase tipo)
        {
            switch (tipo)
            {
                default:
                case TipoDatabase.Firebird:
                case TipoDatabase.MySql:
                case TipoDatabase.PostgreSql:
                    return new Dictionary<TipoDadoEnum, string>
                    {
                        { TipoDadoEnum.Bool, "char(1)" },
                        { TipoDadoEnum.Date, "timestamp" },
                        { TipoDadoEnum.Real, "numeric{tam}" },
                        { TipoDadoEnum.Int, "integer" },
                        { TipoDadoEnum.Str, "varchar{tam}" },
                    };
                case TipoDatabase.Oracle:
                    return new Dictionary<TipoDadoEnum, string>
                    {
                        { TipoDadoEnum.Bool, "char(1)" },
                        { TipoDadoEnum.Date, "date" },
                        { TipoDadoEnum.Real, "number{tam}" },
                        { TipoDadoEnum.Int, "integer" },
                        { TipoDadoEnum.Str, "varchar{tam}" },
                    };
                case TipoDatabase.SqLite:
                    return new Dictionary<TipoDadoEnum, string>
                    {
                        { TipoDadoEnum.Bool, "text" },
                        { TipoDadoEnum.Date, "text" },
                        { TipoDadoEnum.Real, "real" },
                        { TipoDadoEnum.Int, "integer" },
                        { TipoDadoEnum.Str, "text" },
                    };
            }
        }

        public static string GetDataType(this TipoDatabase tipo, CampoAttribute campo)
        {
            var types = tipo.GetTypes();
            var tipoDado = campo.DataType.GetTipoDadoModel();
            var str = types[tipoDado.TipoDado];
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