using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public static class CsvExtensions
    {
        #region constantes
        private const string _formatoDataCsv = "dd/MM/yyyy HH:mm:ss";
        #endregion
        #region metodos        
        #region metodos publicos
        public static string GetCsv<TObject>(this IList<TObject> lista)
        {
            if (lista == null)
                return null;

            var retorno = new List<string>();

            var campos = GetCampos<TObject>();
            retorno.Add(campos);

            foreach(var item in lista)
            {
                var linha = GetLinha(item);
                retorno.Add(linha);
            }

            return string.Join("\n", retorno);
        }
        public static IList<TObject> GetListaFromCsv<TObject>(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            var retorno = new List<TObject>();

            var linhas = value
                .Replace("\r", "")
                .GetLista('\n')
                ;

            var campos = linhas.GetParte(0)?.GetLista(';');

            for(var l = 1; l < linhas.Length; l++)
            {
                var valores = linhas[l].GetLista(';');

                SetRetorno(campos, valores, retorno);
            }

            return retorno;
        }
        #endregion
        #region metodos privados
        private static string GetCampos<TObject>()
        {
            var retorno = new List<string>();

            typeof(TObject)
                .GetProperties()
                .ToList()
                .ForEach(p => retorno.Add(p.Name))
                ;

            return string.Join(";", retorno);
        }
        private static string GetLinha<TObject>(TObject item)
        {
            var retorno = new List<string>();

            typeof(TObject)
                .GetProperties()
                .ToList()
                .ForEach(p => retorno.Add(p.GetValueCsv(p.GetValue(item))))
                ;

            return string.Join(";", retorno);
        }
        private static string GetValueCsv(this PropertyInfo prop, object value)
        {
            var tipoDado = prop.GetTipoDadoModel();
            var tamanho = prop.GetTamanho();
            var valor = string.Empty;

            switch (tipoDado.Dado)
            {
                case TipoDado.Bool:
                    valor = ((bool)value) ? "T" : "F";
                    break;
                case TipoDado.Date:
                    valor = ((DateTime)value).ToString(_formatoDataCsv);
                    break;
                case TipoDado.Real:
                    valor = ((double)value).ToString();
                    break;
                case TipoDado.Int:
                    valor = ((int)value).ToString();
                    break;
                case TipoDado.Str:
                    valor = ((string)value);
                    break;
                case TipoDado.Enum:
                    valor = ((int)value).ToString();
                    break;
            }

            if (valor == null)
                valor = string.Empty;

            return valor;
        }
        private static void SetRetorno<TObject>(string[] campos, string[] valores, List<TObject> retorno)
        {
            var item = Activator.CreateInstance<TObject>();
            retorno.Add(item);

            var index = 0;
            foreach (var campo in campos)
            {
                var valor = valores.GetParte(index);
                var prop = typeof(TObject).GetProperty(campo);
                var valorProp = prop.GetValorPropCsv(valor);
                item.SetInstancePropOrField(campo, valorProp);
                index++;
            }
        }
        private static object GetValorPropCsv(this PropertyInfo prop, string valor)
        {
            var tipoDado = prop.GetTipoDadoModel();

            if (valor != null)
                valor = valor?.Trim();

            switch (tipoDado.Dado)
            {
                case TipoDado.Bool:
                    return valor.Equals("T");
                case TipoDado.Date:
                    return valor.ObterDataHora();
                case TipoDado.Real:
                    return Convert.ToDouble(valor.ObterValor());
                case TipoDado.Int:
                    return Convert.ToInt32(valor.ObterNumero());
                case TipoDado.Str:
                    return valor?.Trim() ?? string.Empty;
                case TipoDado.Enum:
                    return Convert.ToInt32(valor.ObterNumero());
            }

            return null;
        }
        #endregion
        #endregion
    }
}