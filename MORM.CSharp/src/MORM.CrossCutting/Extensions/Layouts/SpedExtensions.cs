using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public static class SpedExtensions
    {
        #region constantes
        private const string _formatoDataEdi = "yyyy-MM-ddTHH:mm:ss";
        #endregion
        #region metodos
        #region metodos publicos
        public static string GetSped<TObject>(this IList<TObject> lista)
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
        public static IList<TObject> GetListaFromSped<TObject>(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            var retorno = new List<TObject>();

            var linhas = value
                .Replace("\r", "")
                .GetLista('\n')
                ;

            var campos = new List<string>();

            for (var l = 1; l < linhas.Length; l++)
            {
                var linha = linhas[l];
                var valores = linha.GetLista('|');
                var tipo = valores.GetParte(1);

                switch (tipo)
                {
                    case "C":
                        SetColunas(campos, valores);
                        break;
                    case "R":
                        SetRetorno(campos, valores, retorno);
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
            retorno.Add(typeof(TObject).Name);

            return "|" + string.Join("|", retorno) + "|";
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
                    coluna.Add(p.Name);
                    retorno.Add("|" + string.Join("|", coluna) + "|");
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
                .ForEach(p => retorno.Add(p.GetValueSped(p.GetValue(item))))
                ;

            return "|" + string.Join("|", retorno) + "|";
        }
        private static int GetTamanhoSped(this PropertyInfo prop)
        {
            var campoDef = prop.Name.GetCampoDefinicao();
            return campoDef?.Tamanho ?? 10;
        }
        private static string GetValueSped(this PropertyInfo prop, object value)
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

            return valor;
        }
        private static void SetColunas(List<string> colunas, string[] valores)
        {
            var nome = valores.GetParte(2);
            colunas.Add(nome);
        }
        private static void SetRetorno<TObject>(List<string> campos, string[] valores, List<TObject> retorno)
        {
            var item = Activator.CreateInstance<TObject>();
            retorno.Add(item);

            var index = 2;
            foreach (var campo in campos)
            {
                var valor = valores.GetParte(index);
                var prop = typeof(TObject).GetProperty(campo);
                var valorProp = prop.GetValorPropSped(valor);
                item.SetInstancePropOrField(campo, valorProp);
                index++;
            }
        }
        private static object GetValorPropSped(this PropertyInfo prop, string valor)
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