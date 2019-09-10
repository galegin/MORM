using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MORM.CrossCutting
{
    public static class LogsExtension
    {
        public static List<Log> GetLista(this string nomeArquivo)
        {
            if (!File.Exists(nomeArquivo))
                return null;

            var xmlString = File.ReadAllText(nomeArquivo);

            xmlString = 
                "<Logs>" + 
                xmlString.RemoveAcento() + 
                "</Logs>";

            XmlSerializer serializer = new XmlSerializer(typeof(List<Log>), new XmlRootAttribute("Logs"));

            StringReader stringReader = new StringReader(xmlString);

            return (List<Log>)serializer.Deserialize(stringReader);
        }
    }
}