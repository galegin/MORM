using System.Collections.Generic;
using System.Drawing.Printing;

namespace MORM.Infra.CrossCutting
{
    public class PrinterExtensions
    {
        #region Metodos
        public static string GetPrinterNamePadrao()
        {
            var printerSettings = new PrinterSettings();
            return printerSettings.PrinterName;
        }

        public static List<string> GetPrinters()
        {
            var printers = new List<string>();
            foreach (var printer in PrinterSettings.InstalledPrinters)
                printers.Add(printer.ToString());
            return printers;
        }
        #endregion
    }
}