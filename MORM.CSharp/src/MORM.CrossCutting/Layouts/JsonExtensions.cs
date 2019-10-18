using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace MORM.CrossCutting
{
    public static class JsonExtensions
    {
        private static Dictionary<Type, object> _listaDeObj = new Dictionary<Type, object>();

        public static List<TObject> GetListaFromJson<TObject>(this string arquivo, string conteudoPadrao = null)
        {
            var lista = _listaDeObj.ContainsKey(typeof(TObject)) ? _listaDeObj[typeof(TObject)] : null;
            if (lista == null)
            {
                var conteudo = string.Empty;
                if (File.Exists(arquivo))
                    conteudo = File.ReadAllText(arquivo);

                if (string.IsNullOrWhiteSpace(conteudo) && !string.IsNullOrWhiteSpace(conteudoPadrao))
                    conteudo = conteudoPadrao;

                if (!string.IsNullOrWhiteSpace(conteudo))
                    lista = conteudo.GetObjectFromJson<List<TObject>>();
                else
                    lista = new List<TObject>();
            };

            return lista as List<TObject>;
        }
        
        public static void SetListaFromJson<TObject>(this List<TObject> lista, string arquivo)
        {
            var conteudo = lista.GetJson();
            File.WriteAllText(arquivo, conteudo);
        }

        public static string GetJson(this object obj, bool isIndented = false)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeJavaScriptConverter() });
            return javaScriptSerializer.Serialize(obj);
        }

        public static object GetObjectFromJson(this string str, Type type)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeJavaScriptConverter() });
            return javaScriptSerializer.Deserialize(str, type);
        }

        public static TObject GetObjectFromJson<TObject>(this string str) where TObject : class
        {
            return str.GetObjectFromJson(typeof(TObject)) as TObject;
        }
    }

    public class DateTimeJavaScriptConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            return new JavaScriptSerializer().ConvertToType(dictionary, type);
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            if (!(obj is DateTime)) return null;
            return new CustomString(((DateTime)obj).ToUniversalTime().ToString("O"));
        }

        public override IEnumerable<Type> SupportedTypes
        {
            get { return new[] { typeof(DateTime) }; }
        }

        private class CustomString : Uri, IDictionary<string, object>
        {
            public CustomString(string str)
              : base(str, UriKind.Relative)
            {
            }

            void IDictionary<string, object>.Add(string key, object value)
            {
                throw new NotImplementedException();
            }

            bool IDictionary<string, object>.ContainsKey(string key)
            {
                throw new NotImplementedException();
            }

            ICollection<string> IDictionary<string, object>.Keys
            {
                get { throw new NotImplementedException(); }
            }

            bool IDictionary<string, object>.Remove(string key)
            {
                throw new NotImplementedException();
            }

            bool IDictionary<string, object>.TryGetValue(string key, out object value)
            {
                throw new NotImplementedException();
            }

            ICollection<object> IDictionary<string, object>.Values
            {
                get { throw new NotImplementedException(); }
            }

            object IDictionary<string, object>.this[string key]
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }

            void ICollection<KeyValuePair<string, object>>.Clear()
            {
                throw new NotImplementedException();
            }

            bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }

            void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            int ICollection<KeyValuePair<string, object>>.Count
            {
                get { throw new NotImplementedException(); }
            }

            bool ICollection<KeyValuePair<string, object>>.IsReadOnly
            {
                get { throw new NotImplementedException(); }
            }

            bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }

            IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }

}