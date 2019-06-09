using MORM.Dominio.Extensoes;
using System.Xml.Serialization;

namespace MORM.Dominio.Tipagens
{
    public enum CampoPreFixo
    {
        [XmlEnum("Cd")]
        Codigo,

        [XmlEnum("Dt")] 
        Data,

        [XmlEnum("Dh")]
        DataHora,

        [XmlEnum("Ds")]
        Descricao,

        [XmlEnum("Hr")]
        Hora,

        [XmlEnum("Id")]
        Identificacao,

        [XmlEnum("In")]
        Indicador,

        [XmlEnum("Nm")]
        Nome,

        [XmlEnum("Nr")]
        Numero,

        [XmlEnum("Qt")]
        Quantidade,

        [XmlEnum("Pr")]
        Percentual,

        [XmlEnum("U")]
        Version,

        [XmlEnum("Vl")]
        Valor,
    }

    public static class CampoPreFixoExtension
    {
        public static string GetXmlEnum(this CampoPreFixo campoPreFixo)
        {
            return EnumExtensions.GetValueFromEnum(campoPreFixo);
        }

        public static CampoPreFixo? GetCampoPreFixo(this string campo)
        {
            var preFixo = campo.Split('_')[0];

            foreach (var name in System.Enum.GetNames(typeof(CampoPreFixo)))
            {
                var campoPreFixo = (CampoPreFixo)System.Enum.Parse(typeof(CampoPreFixo), name);
                var xmlEnum = EnumExtensions.GetValueFromEnum(campoPreFixo);
                if (xmlEnum.Equals(preFixo))
                {
                    return campoPreFixo;
                }
            }

            return null;
        }
    }
}