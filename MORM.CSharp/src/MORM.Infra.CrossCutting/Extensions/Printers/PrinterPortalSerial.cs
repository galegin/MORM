using System;
using System.Runtime.InteropServices;

namespace MORM.Infra.CrossCutting
{
    public class ImpressaoPortaSerial //: IImpressaoPortaSerial
    {
        /*
        #region Variaveis
        private const string _mensagemSucesso = "Impressao executada com sucesso";
        private string _printerName;
        #endregion

        #region Metodos

        #region Metodos Publicos
        public object Imprimir(object parametros)
        {
            var model = parametros as PrinterImprimirConteudoInModel;

            _printerName = model.GetPrinterName();

            return ImprimirConteudoModel(model);
        }

        #endregion

        #region Metodos Privados
        private object ImprimirConteudoModel(PrinterImprimirConteudoInModel model)
        {
            model.ConteudosImpressao
                .ForEach(conteudo => ImprimirConteudo(conteudo));

            return _mensagemSucesso;
        }

        private void ImprimirConteudo(PrinterConteudoInModel conteudo)
        {
            PrintString(conteudo.Conteudo);
        }

        public bool PrintString(string data, bool cortaPapel = true)
        {
            if (_printerName?.Contains("EPSON") == true)
                data += "\r\n\r\n";

            if (cortaPapel)
                data += ImpressoraComando.CortaPapel;

            var dwCount = (data.Length + 1) * Marshal.SystemMaxDBCSCharSize;
            var pBytes = Marshal.StringToCoTaskMemAnsi(data);

            PrintBytes(pBytes, dwCount, "", dataType: "RAW");
            Marshal.FreeCoTaskMem(pBytes);

            return true;
        }

        private bool PrintBytes(IntPtr bytes, int count, string documentName = "", string dataType = "RAW")
        {
            bool bSuccess = true;
            DOCINFOA di = new DOCINFOA();
            di.pDocName = documentName;
            di.pDataType = dataType;

            if (OpenPrinter(_printerName.Normalize(), out IntPtr hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        bSuccess = WritePrinter(hPrinter, bytes, count, out int dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }

            if (bSuccess == false)
            {
                var dwError = Marshal.GetLastWin32Error();
            }

            return bSuccess;
        }
        #endregion

        #endregion
        */
    }
}