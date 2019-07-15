using MORM.Apresentacao.Report.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MORM.Apresentacao.Report.Classes
{
    public class RelatorioImpressora : IRelatorioImpressora
    {
        public RelatorioImpressora(string[] conteudo, string nomeImpressora = null)
        {
            _conteudo = conteudo ?? throw new ArgumentNullException(nameof(conteudo));
            _nomeImpressora = nomeImpressora;
        }

        private readonly string[] _conteudo;
        private readonly string _nomeImpressora;

        private string _texto;
        private PrintDocument _printDocument;
        private PrintPreviewDialog _printPreviewDialog;

        private void SetPrintDocument()
        {
            _texto = string.Join("\r\n", _conteudo);

            _printDocument = new PrintDocument();
            _printDocument.PrintPage += PrintDocument_PrintPage;
            _printDocument.PrinterSettings.PrinterName = _nomeImpressora;

            Margins margins = new Margins(10, 10, 10, 10);
            _printDocument.DefaultPageSettings.Margins = margins;
        }

        private void SetPrintPreviewDialog()
        {
            _printPreviewDialog = new PrintPreviewDialog();
            _printPreviewDialog.Document = _printDocument;
            ((Form)_printPreviewDialog).WindowState = FormWindowState.Maximized;

            int PreferredZoomValue = 150;
            _printPreviewDialog.PrintPreviewControl.Zoom = PreferredZoomValue / 100f;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var printDocument = sender as PrintDocument;

            if (printDocument != null)
            {
                using (var fonte = new Font("Lucida console", 8))
                using (var brush = new SolidBrush(Color.Black))
                {
                    int caracteresNaPagina = 0;
                    int linhasPorPagina = 0;

                    e.Graphics.MeasureString(
                        _texto, fonte, e.MarginBounds.Size, StringFormat.GenericTypographic,
                        out caracteresNaPagina, out linhasPorPagina);

                    e.Graphics.DrawString(
                        _texto.Substring(0, caracteresNaPagina),
                        fonte,
                        brush,
                        e.MarginBounds);

                    _texto = _texto.Substring(caracteresNaPagina);

                    e.HasMorePages = _texto.Length > 0;
                }
            }
        }

        public void Imprimir()
        {
            SetPrintDocument();

            _printDocument.Print();
        }

        public void Visualizar()
        {
            SetPrintDocument();
            SetPrintPreviewDialog();

            _printPreviewDialog.ShowDialog();
        }
    }
}