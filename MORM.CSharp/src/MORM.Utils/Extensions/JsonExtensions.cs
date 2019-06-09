using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MORM.Utils.Extensions
{
    public static class JsonExtensions
    {
        private static Dictionary<Type, object> _listaDeObj =
            new Dictionary<Type, object>();

        public static List<TObj> GetLista<TObj>(this string arquivo, string conteudoPadrao = null)
        {
            var lista = _listaDeObj.ContainsKey(typeof(TObj)) ? _listaDeObj[typeof(TObj)] : null;
            if (lista == null)
            {
                var conteudo = string.Empty;
                if (File.Exists(arquivo))
                    conteudo = File.ReadAllText(arquivo);

                if (string.IsNullOrWhiteSpace(conteudo) && !string.IsNullOrWhiteSpace(conteudoPadrao))
                    conteudo = conteudoPadrao;

                if (!string.IsNullOrWhiteSpace(conteudo))
                    lista = JsonConvert.DeserializeObject<List<TObj>>(conteudo);
                else
                    lista = new List<TObj>();
            };

            return lista as List<TObj>;
        }

        public static string GetJsonFromObject<TObj>(this TObj obj, bool isIndented = false)
        {
            return JsonConvert.SerializeObject(obj, isIndented ? Formatting.Indented : Formatting.None);
        }

        public static TObj GetObjectFromJson<TObj>(this string str)
        {
            return JsonConvert.DeserializeObject<TObj>(str);
        }
    }
}