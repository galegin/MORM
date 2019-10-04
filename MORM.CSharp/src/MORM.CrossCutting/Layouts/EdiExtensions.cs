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

            var classe = GetClasse<TObject>();
            retorno.Add(classe);

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

            var colunas = new Dictionary<string, int>();

            for (var l = 0; l < linhas.Length; l++)
            {
                var linha = linhas[l];
                var tipo = linha.Substring(0, 1);
                linha = linha.Substring(1);

                switch (tipo)
                {
                    case "C":
                        SetColunas(colunas, linha);
                        break;
                    case "R":
                        SetRetorno(colunas, linha, retorno);
                        break;
                }
            }

            return retorno;
        }
        #endregion
        #region metodos privados
        private static string GetClasse<TObject>()
        {
            var retorno = new List<string>();
            retorno.Add("A");
            retorno.Add(typeof(TObject).Name.PadRight(30));

            return string.Join("", retorno);
        }
        private static string GetColunas<TObject>()
        {
            var retorno = new List<string>();
            var coluna = new List<string>();

            typeof(TObject)
                .GetProperties()
                .ToList()
                .ForEach(p =>
                {
                    coluna.Clear();
                    coluna.Add("C");
                    coluna.Add(p.Name.PadRight(30));
                    coluna.Add(p.GetTamanhoEdi().ToString().PadLeft(4, '0'));
                    retorno.Add(string.Join("", coluna));
                })
                ;

            return string.Join("\n", retorno);
        }
        private static string GetLinha<TObject>(TObject item)
        {
            var retorno = new List<string>();
            retorno.Add("R");

            typeof(TObject)
                .GetProperties()
                .ToList()
                .ForEach(p => retorno.Add(p.GetValueEdi(p.GetValue(item))))
                ;

            return string.Join("", retorno);
        }
        private static int GetTamanhoEdi(this PropertyInfo prop)
        {
            var tipoDado = prop.GetTipoDadoModel();
            if (tipoDado.Dado == TipoDado.Date)
                return _formatoDataEdi.Length;

            var campoDef = prop.Name.GetCampoDefinicao();
            return campoDef?.Tamanho ?? 10;
        }
        private static string GetValueEdi(this PropertyInfo prop, object value)
        {
            var tipoDado = prop.GetTipoDadoModel();
            var tamanho = prop.GetTamanhoEdi();
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
                    valor = (((double)value) * 1000).ToString();
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
                    valor = valor.PadRight(tamanho);
                    break;
                case TipoDado.Real:
                case TipoDado.Int:
                    valor = valor.PadLeft(tamanho, '0');
                    break;
                default:
                case TipoDado.Str:
                    valor = valor.PadRight(tamanho);
                    break;
            }

            return valor;
        }
        private static void SetColunas(Dictionary<string, int> colunas, string linha)
        {
            var nome = linha.Substring(0, 30).Trim();
            linha = linha.Substring(30);
            var tamanhoStr = linha.Substring(0, 4);
            int.TryParse(tamanhoStr, out int tamanho);
            colunas[nome] = tamanho;
        }
        private static void SetRetorno<TObject>(Dictionary<string, int> colunas, string linha, List<TObject> retorno)
        {
            var item = Activator.CreateInstance<TObject>();
            retorno.Add(item);

            foreach (var coluna in colunas)
            {
                var campo = coluna.Key;
                var tamanho = coluna.Value;
                var valor = linha.Substring(0, tamanho);
                linha = linha.Substring(tamanho);
                var prop = typeof(TObject).GetProperty(campo);
                var valorProp = prop.GetValorPropEdi(valor);
                item.SetInstancePropOrField(campo, valorProp);
            }
        }
        private static object GetValorPropEdi(this PropertyInfo prop, string valor)
        {
            var tipoDado = prop.GetTipoDadoModel();

            if (valor != null)
                valor = valor?.Trim();

            switch (tipoDado.Dado)
            {
                case TipoDado.Bool:
                    return valor.Equals("T");
                case TipoDado.Date:
                    return valor.ObterDataHoraInv();
                case TipoDado.Real:
                    return Convert.ToDouble(valor.ObterValor() / 1000);
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