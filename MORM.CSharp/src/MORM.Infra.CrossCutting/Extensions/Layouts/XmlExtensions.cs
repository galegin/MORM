using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MORM.Infra.CrossCutting
{
    /* 
    [XmlRoot("teste")]
    public class Teste
    {
        [XmlElement("codigo")]
        public string Codigo { get; set; }
        
        [XmlElement("descricao")]
        public string Descricao { get; set; }
    }
    */
    public static class XmlExtensions
    {
        #region metodos

        #region metodos publicos
        public static TInstance GetInstance<TInstance>(this string xml)
            where TInstance : class
        {
            return ObjectToXML(xml, typeof(TInstance)) as TInstance;
        }

        //public static TInstance GetInstanceComRootXml<TInstance>(this string xml)
        //   where TInstance : class
        //{
        //    return ObjectToXML(xml.GetConteudoComXmlRoot<TInstance>(), typeof(TInstance)) as TInstance;
        //}

        public static TInstance GetInstanceFromFile<TInstance>(this string arquivo)
          where TInstance : class
        {
            var conteudo = ArquivoDiretorio.CarregarArquivo(arquivo);
            return !string.IsNullOrWhiteSpace(conteudo) ? conteudo.GetInstance<TInstance>() : null;
        }

        public static string GetXml(this object objeto)
        {
            return GetXMLFromObject(objeto);
        }
        #endregion

        #region metodos privados
        private static string GetXMLFromObject(object obj)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, obj);
            }
            catch //(Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }

        public static object ObjectToXML(string xml, Type objectType)
        {
            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            object obj = null;
            try
            {
                strReader = new StringReader(xml);
                serializer = new XmlSerializer(objectType);
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch //(Exception exp)
            {
                //Handle Exception Code
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return obj;
        }
        #endregion

        #endregion
    }
}