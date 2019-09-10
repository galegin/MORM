using MORM.Dominio.Atributos;
using MORM.CrossCutting;
using System;
using System.Reflection;

namespace MORM.Apresentacao.Controls
{
    public enum AbstractCampoFormato
    {
        [Formato("", "")]
        Bool, 

        [Formato("dd/MM/yyyy", "[^0-9/]+")]
        Data,

        [Formato("yyyy", "[^0-9]+")]
        DataAno,

        [Formato("dd/MM/yyyy HH:mm", "[^0-9 /:]+")]
        DataHora,

        [Formato("dd/MM/yyyy HH:mm:ss", "[^0-9 /:]+")]
        DataHoraSegundo,

        [Formato("MM/yyyy", "[^0-9/]+")]
        DataRef,

        [Formato("HH:mm", "[^0-9:]+")]
        Hora,

        [Formato("HH:mm:ss", "[^0-9:]+")]
        HoraSegundo,

        [Formato("#,#0", "[^0-9.-]")]
        Numero,

        [Formato("", "[^0-9A-Za-z !@#$%&().,-]+")]
        Texto,

        [Formato("#,#0.00", "[^0-9.,-]")]
        Valor
    }

    public static class AbstractCampoFormatoExtensions
    {
        public static string GetFormato(this AbstractCampoFormato tipo)
        {
            return EnumExtensions.GetAtributeEnum<AbstractCampoFormato, FormatoAttribute>(tipo.ToString())?.Conteudo;
        }

        public static string GetValidacao(this AbstractCampoFormato tipo)
        {
            return EnumExtensions.GetAtributeEnum<AbstractCampoFormato, FormatoAttribute>(tipo.ToString())?.Validacao;
        }

        public static string GetFormatValue(this AbstractCampoFormato tipo, string texto)
        {
            if (texto == null)
                return null;

            var formato = tipo.GetFormato();
            var value = tipo.GetValue(texto);

            if (value == null)
                return null;

            switch (tipo)
            {
                case AbstractCampoFormato.Data:
                case AbstractCampoFormato.DataAno:
                case AbstractCampoFormato.DataHora:
                case AbstractCampoFormato.DataHoraSegundo:
                case AbstractCampoFormato.DataRef:
                case AbstractCampoFormato.Hora:
                case AbstractCampoFormato.HoraSegundo:
                    return Convert.ToDateTime(value).ToString(formato);

                case AbstractCampoFormato.Numero:
                case AbstractCampoFormato.Valor:
                    return Convert.ToDouble(value).ToString(formato);

                default:
                case AbstractCampoFormato.Texto:
                    return value.ToString();
            }
        }

        private static string GetValueOnlyNumber(this string text)
        {
            return text?.Replace(".", "");
        }

        public static object GetValue(this AbstractCampoFormato tipo, string value)
        {
            if (value == null)
                return null;

            var formato = tipo.GetValidacao();

            switch (tipo)
            {
                case AbstractCampoFormato.Data:
                    return value.ObterData();

                case AbstractCampoFormato.DataAno:
                    return value.ObterDataAno();

                case AbstractCampoFormato.DataHora:
                case AbstractCampoFormato.DataHoraSegundo:
                    return value.ObterDataHora();

                case AbstractCampoFormato.DataRef:
                    return value.ObterDataRef();

                case AbstractCampoFormato.Hora:
                case AbstractCampoFormato.HoraSegundo:
                    return value.ObterHora();

                case AbstractCampoFormato.Numero:
                    return value.GetValueOnlyNumber().ObterNumero();

                default:
                case AbstractCampoFormato.Texto:
                    return value;

                case AbstractCampoFormato.Valor:
                    return value.GetValueOnlyNumber().ObterValor();
            }
        }

        public static AbstractCampoFormato GetCampoFormato(this PropertyInfo prop)
        {
            var tipoDado = prop.PropertyType.GetTipoDadoModel();

            switch (tipoDado.Dado)
            {
                case TipoDado.Bool:
                    return AbstractCampoFormato.Bool;
                case TipoDado.Date:
                    return AbstractCampoFormato.Data;
                case TipoDado.Real:
                    return AbstractCampoFormato.Valor;
                case TipoDado.Int:
                    return AbstractCampoFormato.Numero;
                case TipoDado.Str:
                    return AbstractCampoFormato.Texto;
            }

            return AbstractCampoFormato.Texto;
        }
    }
}