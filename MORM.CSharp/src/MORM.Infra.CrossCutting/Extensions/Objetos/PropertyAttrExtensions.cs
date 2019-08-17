using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public static class PropertyAttrExtensions
    {
        private static string[] _ignoreCampos =
            { "U_Version", "Cd_Operador", "Dt_Cadastro", "Cd_Senha" };

        public static bool IsIgnoreCampo(this string campo)
        {
            return _ignoreCampos.Contains(campo);
        }

        public static bool IsIgnoreCampo(this PropertyInfo prop)
        {
            return prop.Name.IsIgnoreCampo();
        }

        public static string GetDescricao(this PropertyInfo prop)
        {
            var description = prop.GetAttribute<DescriptionAttribute>();
            if (description != null)
                return description.Description;
            return prop.Name;
        }

        //public static DescriptionAttribute GetDescription(this PropertyInfo prop)
        //{
        //    return prop.GetAttribute<DescriptionAttribute>();
        //}

        //public static StringLengthAttribute GetStringLength(this PropertyInfo prop)
        //{
        //    return prop.GetAttribute<StringLengthAttribute>();
        //}

        public static string GetFormato(this PropertyInfo prop)
        {
            var formato = prop.GetAttribute<DisplayAttribute>()?.Description;
            if (!string.IsNullOrWhiteSpace(formato))
                return formato;

            var tipoDado = prop.PropertyType.GetTipoDadoModel();

            switch (tipoDado.TipoDado)
            {
                case TipoDadoEnum.Bool:
                    return null;
                case TipoDadoEnum.Date:
                    return "dd/MM/yyyy";
                case TipoDadoEnum.Real:
                    var precisao = prop.GetPrecisao();
                    var precisaoStr = precisao > 0 ? "." + new string('0', precisao) : string.Empty;
                    return $"#,##0{precisaoStr}";
                case TipoDadoEnum.Int:
                    return "#,##0";
                case TipoDadoEnum.Str:
                    return null;
            }

            return null;
        }

        public static int GetTamanho(this PropertyInfo prop)
        {
            var tamanho = prop.GetAttribute<MaxLengthAttribute>()?.Length ?? 0;
            if (tamanho != 0)
                return tamanho;

            var tipoDado = prop.PropertyType.GetTipoDadoModel();

            switch (tipoDado.TipoDado)
            {
                case TipoDadoEnum.Bool:
                    return 10;
                case TipoDadoEnum.Date:
                    return 10;
                case TipoDadoEnum.Real:
                    return 10;
                case TipoDadoEnum.Int:
                    return 10;
                case TipoDadoEnum.Str:
                    return 50;
            }

            return 10;
        }

        public static int GetPrecisao(this PropertyInfo prop)
        {
            var precisao = prop.GetAttribute<MinLengthAttribute>()?.Length ?? 0;
            if (precisao != 0)
                return precisao;

            var tipoDado = prop.PropertyType.GetTipoDadoModel();

            switch (tipoDado.TipoDado)
            {
                case TipoDadoEnum.Bool:
                    return 0;
                case TipoDadoEnum.Date:
                    return 0;
                case TipoDadoEnum.Real:
                    return 2;
                case TipoDadoEnum.Int:
                    return 0;
                case TipoDadoEnum.Str:
                    return 0;
            }

            return 0;
        }
    }
}