using MORM.Utilidade.Atributos;
using MORM.Utilidade.Extensoes;
using System;

namespace MORM.Apresentacao.Controls
{
    public enum AbstractEditTipo
    {
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

        [Formato("", "[^0-9A-Za-z !@#$%&()]+")]
        Texto,

        [Formato("#,#0.00", "[^0-9.,-]")]
        Valor
    }

    public static class AbstractEditTipoExtensions
    {
        public static string GetFormato(this AbstractEditTipo tipo)
        {
            return EnumExtensions.GetAtributeEnum<AbstractEditTipo, FormatoAttribute>(tipo.ToString())?.Conteudo;
        }

        public static string GetValidacao(this AbstractEditTipo tipo)
        {
            return EnumExtensions.GetAtributeEnum<AbstractEditTipo, FormatoAttribute>(tipo.ToString())?.Validacao;
        }

        public static string GetFormatValue(this AbstractEditTipo tipo, string texto)
        {
            if (texto == null)
                return null;

            var formato = tipo.GetFormato();
            var value = tipo.GetValue(texto);

            if (value == null)
                return null;

            switch (tipo)
            {
                case AbstractEditTipo.Data:
                case AbstractEditTipo.DataAno:
                case AbstractEditTipo.DataHora:
                case AbstractEditTipo.DataHoraSegundo:
                case AbstractEditTipo.DataRef:
                case AbstractEditTipo.Hora:
                case AbstractEditTipo.HoraSegundo:
                    return Convert.ToDateTime(value).ToString(formato);

                case AbstractEditTipo.Numero:
                case AbstractEditTipo.Valor:
                    return Convert.ToDouble(value).ToString(formato);

                default:
                case AbstractEditTipo.Texto:
                    return value.ToString();
            }
        }

        private static string GetValueOnlyNumber(this string text)
        {
            return text?.Replace(".", "");
        }

        public static object GetValue(this AbstractEditTipo tipo, string value)
        {
            if (value == null)
                return null;

            var formato = tipo.GetValidacao();

            switch (tipo)
            {
                case AbstractEditTipo.Data:
                    return value.ObterData();

                case AbstractEditTipo.DataAno:
                    return value.ObterDataAno();

                case AbstractEditTipo.DataHora:
                case AbstractEditTipo.DataHoraSegundo:
                    return value.ObterDataHora();

                case AbstractEditTipo.DataRef:
                    return value.ObterDataRef();

                case AbstractEditTipo.Hora:
                case AbstractEditTipo.HoraSegundo:
                    return value.ObterHora();

                case AbstractEditTipo.Numero:
                    return value.GetValueOnlyNumber().ObterNumero();

                default:
                case AbstractEditTipo.Texto:
                    return value;

                case AbstractEditTipo.Valor:
                    return value.GetValueOnlyNumber().ObterValor();
            }
        }
    }
}