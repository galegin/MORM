using System.Xml.Serialization;

namespace MORM.CrossCutting
{
    [XmlType("log")]
    public class Log
    {
        [XmlElement("data")]
        public string Data { get; set; }

        [XmlElement("tipo")]
        public string Tipo { get; set; }

        [XmlElement("message")]
        public string Mensagem { get; set; }

        [XmlElement("metodo")]
        public string Metodo { get; set; }
    }

    [XmlRoot("Logs")]
    public class Logs
    {
        [XmlElement("log")]
        public Log[] Log { get; set; }
    }
}