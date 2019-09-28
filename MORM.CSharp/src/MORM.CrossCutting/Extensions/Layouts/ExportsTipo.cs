using System;
using System.IO;

namespace MORM.CrossCutting
{
    public enum ExportsTipo
    {
        Csv,
        Edi,
        Json,
        Xml,
        Zip
    }

    public static class ExportsTipoExtensions
    {
        public static ExportsTipo GetExportsTipo(this string arquivo)
        {
            var extensao = Path.GetExtension(arquivo).Replace(".", "");
            Enum.TryParse(extensao, true, out ExportsTipo tipo);
            return tipo;
        }
    }
}