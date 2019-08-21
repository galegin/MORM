using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public static class PropertyAttrExtensions
    {
        private static Dictionary<string, object> _ignoreCampos = 
            new Dictionary<string, object>
            {
                ["U_Version"] = "",
                ["Cd_Operador"] = 1,
                ["Cd_OperIncl"] = 1,
                ["Dt_Cadastro"] = DateTime.Now,
                ["Dt_Inclusao"] = DateTime.Now,
                ["Cd_Senha"] = "123@mudar"
            };

        public static void SetCampoPadrao(this object model)
        {
            _ignoreCampos["Dt_Cadastro"] = DateTime.Now;
            _ignoreCampos["Dt_Inclusao"] = DateTime.Now;

            foreach (var campo in _ignoreCampos)
                model.SetInstancePropOrField(campo.Key, campo.Value);
        }

        public static bool IsIgnoreCampo(this string campo)
        {
            return _ignoreCampos.ContainsKey(campo);
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

        public static string GetFormato(this PropertyInfo prop)
        {
            var formato = prop.GetAttribute<DisplayAttribute>()?.Description;
            if (!string.IsNullOrWhiteSpace(formato))
                return formato;

            var tipoDado = prop.PropertyType.GetTipoDadoModel();

            switch (tipoDado.Dado)
            {
                case TipoDado.Bool:
                    return null;
                case TipoDado.Date:
                    return "dd/MM/yyyy";
                case TipoDado.Real:
                    var precisao = prop.GetPrecisao();
                    var precisaoStr = precisao > 0 ? "." + new string('0', precisao) : string.Empty;
                    return $"#,##0{precisaoStr}";
                case TipoDado.Int:
                    return "#,##0";
                case TipoDado.Str:
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

            switch (tipoDado.Dado)
            {
                case TipoDado.Bool:
                    return 10;
                case TipoDado.Date:
                    return 10;
                case TipoDado.Real:
                    return 10;
                case TipoDado.Int:
                    return 10;
                case TipoDado.Str:
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

            switch (tipoDado.Dado)
            {
                case TipoDado.Bool:
                    return 0;
                case TipoDado.Date:
                    return 0;
                case TipoDado.Real:
                    return 2;
                case TipoDado.Int:
                    return 0;
                case TipoDado.Str:
                    return 0;
            }

            return 0;
        }
    }
}