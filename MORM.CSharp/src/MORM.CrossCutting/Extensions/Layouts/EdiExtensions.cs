using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public static class EdiExtensions
    {
        #region constantes
        private const string _formatoDataEdi = "yyyyMMddHHmmss";
        #endregion
        #region metodos
        #region metodos publicos
        public static string GetEdi<TObject>(this IList<TObject> lista)
        {
            if (lista == null)
                return null;

            var retorno = new List<string>();

            var colunas = GetColunas<TObject>();
            retorno.Add(colunas);

            foreach (var item in lista)
            {
                var linha = GetLinha(item);
                retorno.Add(linha);
            }

            return string.Join("\n", retorno);
        }
        public static IList<TObject> GetListaFromEdi<TObject>(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            var retorno = new List<TObject>();

            var linhas = value
                .Replace("\r", "")
                .GetLista('\n')
                ;

            var colunas = linhas.GetParte(0)?.GetLista(';');

            for (var l = 1; l < linhas.Length; l++)
            {
                var valores = linhas[l];
                var item = Activator.CreateInstance<TObject>();
                retorno.Add(item);

                for (var c = 0; c < colunas.Length; c++)
                {
                    var coluna = colunas[c].GetLista('=');
                    var campo = coluna.GetParte(0);
                    int.TryParse(coluna.GetParte(1), out int tamanho);
                    var valor = valores.Substring(0, tamanho);
                    valores = valores.Substring(tamanho);
                    item.SetInstancePropOrField(campo, valor);
                }
            }

            return retorno;
        }
        #endregion
        #region metodos privados
        private static string GetColunas<TObject>()
        {
            var retorno = new List<string>();
            retorno.Add("R000");

            typeof(TObject)
                .GetProperties()
                .ToList()
                .ForEach(p => retorno.Add($"{p.Name}={p.GetTamanhoEdi()}"))
                ;

            return string.Join(";", retorno);
        }
        private static string GetLinha<TObject>(TObject item)
        {
            var retorno = new List<string>();
            retorno.Add("R001");

            typeof(TObject)
                .GetProperties()
                .ToList()
                .ForEach(p => retorno.Add(p.GetValueEdi(p.GetValue(item))))
                ;

            return string.Join("", retorno);
        }
        private static int GetTamanhoEdi(this PropertyInfo prop)
        {
            if (prop.Name.Equals("UVersion"))
                return 1;

            var tipoDado = prop.GetTipoDadoModel();

            switch (tipoDado.Dado)
            {
                case TipoDado.Bool:
                    return 1;
                case TipoDado.Date:
                    return _formatoDataEdi.Length;
                case TipoDado.Real:
                    return 15;
                case TipoDado.Int:
                    return 10;
                case TipoDado.Str:
                    return 60;
                case TipoDado.Enum:
                    return 3;
            }

            return 10;
        }
        private static string GetValueEdi(this PropertyInfo prop, object value)
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
                    valor = ((DateTime)value).ToString(_formatoDataEdi);
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

            switch (tipoDado.Dado)
            {
                case TipoDado.Bool:
                case TipoDado.Date:
                case TipoDado.Real:
                case TipoDado.Int:
                    valor = valor.PadRight(tamanho);
                    break;
                default:
                case TipoDado.Str:
                    valor = valor.PadLeft(tamanho);
                    break;
            }

            return valor;
        }
        #endregion
        #endregion
    }
}