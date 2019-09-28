using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.CrossCutting
{
    public static class CsvExtensions
    {
        #region metodos        
        #region metodos publicos
        public static string GetCsv<TObject>(this IList<TObject> lista)
        {
            if (lista == null)
                return null;

            var retorno = new List<string>();

            var colunas = GetColunas<TObject>();
            retorno.Add(colunas);

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

            var colunas = linhas.GetParte(0)?.GetLista(';');

            for(var l = 1; l < linhas.Length; l++)
            {
                var valores = linhas[l].GetLista(';');
                var item = Activator.CreateInstance<TObject>();
                retorno.Add(item);

                for(var c = 0; c < colunas.Length; c++)
                {
                    var coluna = colunas[c];
                    var valor = valores[c];
                    item.SetInstancePropOrField(coluna, valor);
                }
            }

            return retorno;
        }
        #endregion
        #region metodos privados
        private static string GetColunas<TObject>()
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
                .ForEach(p => retorno.Add(p.GetValue(item)?.ToString() ?? string.Empty))
                ;

            return string.Join(";", retorno);
        }
        #endregion
        #endregion
    }
}