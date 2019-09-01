using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace MORM.Infra.CrossCutting
{
    public static class JsonExtensions
    {
        private static Dictionary<Type, object> _listaDeObj =
            new Dictionary<Type, object>();

        public static List<TObj> GetListaFromJson<TObj>(this string arquivo, string conteudoPadrao = null)
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
                    lista = conteudo.GetObjectFromJson<List<TObj>>();
                else
                    lista = new List<TObj>();
            };

            return lista as List<TObj>;
        }
        
        public static void SetListaFromJson<TObj>(this List<TObj> lista, string arquivo)
        {
            var conteudo = lista.GetJsonFromObject();
            File.WriteAllText(arquivo, conteudo);
        }

        public static string GetJsonFromObject<TObj>(this TObj obj, bool isIndented = false)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        public static TObj GetObjectFromJson<TObj>(this string str)
        {
            return new JavaScriptSerializer().Deserialize<TObj>(str);
        }
    }
}