using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace MORM.CrossCutting
{
    public class ImpressaoDispositivo // : IImpressaoDispositivo
    {
        /*
        #region Variaveis
        private const string _mensagemSucesso = "Impressao executada com sucesso";
        private const string _mensagemPrinterInvalida = "Impressora invalida";
        private string _printerName;
        private PrinterConteudoInModel _conteudo;
        private bool _isPrimeiraPagina, _isUltimaPagina;
        private int _alturaImagem, _larguraImagem, _alturaTexto = 0;
        private Font _fonte = new Font("Consolas", 9, FontStyle.Regular);
        private string _conteudoImpressao, _conteudoResto = string.Empty;
        private Image _imagemLogo, _imagemBarraChaveAcesso, _imagemBarra = null;
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
                .ForEach(conteudo => SetarImagemOuCodigoBarra(conteudo));

            model.ConteudosImpressao
                .ForEach(conteudo => ImprimirConteudo(conteudo));

            return _mensagemSucesso;
        }

        private void SetarImagemOuCodigoBarra(PrinterConteudoInModel conteudo)
        {
            var tipoConteudo = conteudo.TipoConteudo.GetConteudoTipo();

            switch (tipoConteudo)
            {
                case ConteudoTipo.CodigoBarra:
                    _imagemBarra = _conteudo.GetConteudoImagemOuCodigoBarra();
                    break;
                case ConteudoTipo.CodigoBarraChaveAcesso:
                    _imagemBarraChaveAcesso = _conteudo.GetConteudoImagemOuCodigoBarra();
                    break;
                case ConteudoTipo.Logotipo:
                    _imagemLogo = _conteudo.GetConteudoImagemOuCodigoBarra();
                    break;
            }
        }

        private void ImprimirConteudo(PrinterConteudoInModel conteudo)
        {
            _conteudo = conteudo;

            _isPrimeiraPagina = true;

            AjusteImagem.RedimensionarImagem(_imagemLogo, out _alturaImagem, out _larguraImagem);

            var printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(OnPrintPage);
            printDocument.PrinterSettings.PrinterName = _printerName;

            if (!printDocument.PrinterSettings.IsValid)
                throw new Exception(_mensagemPrinterInvalida);

            printDocument.Print();
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            int y = 0;

            ConteudoImpressao();

            if (_imagemLogo != null && _isPrimeiraPagina)
            {
                e.Graphics.DrawImage(_imagemLogo, 150 - (_larguraImagem / 2), 0, _larguraImagem, _alturaImagem);
                y = _alturaImagem + 5;
            }

            e.Graphics.DrawString(_conteudoImpressao, _fonte, Brushes.Black, -1, y);
            y += _alturaTexto;

            if (_imagemBarraChaveAcesso != null && _isUltimaPagina)
            {
                e.Graphics.DrawImage(_imagemBarraChaveAcesso, 0, y, e.PageSettings.PrintableArea.Width, _imagemBarraChaveAcesso.Height);
                y += _imagemBarraChaveAcesso.Height;
            }

            if (_imagemBarra != null && _isUltimaPagina)
                e.Graphics.DrawImage(_imagemBarra, 0, y, e.PageSettings.PrintableArea.Width, _imagemBarra.Height);

            e.HasMorePages = !string.IsNullOrEmpty(_conteudoResto);

            _isPrimeiraPagina = false;
        }

        private void ConteudoImpressao()
        {
            var conteudo = "".Coalesce(_conteudoResto, _conteudo.Conteudo);
            _conteudoImpressao = _conteudoResto = string.Empty;

            string[] colunas = conteudo.Replace("\r", "").Split('\n');

            for (int i = 0; i < colunas.Count(); i++)
            {
                if (i <= 65)
                    _conteudoImpressao += colunas[i] + "\n";
                else
                    _conteudoResto += colunas[i] + "\n";
            }

            _isUltimaPagina = string.IsNullOrEmpty(_conteudoResto);
            _alturaTexto = _conteudoImpressao.Split('\n').Count();
            _alturaTexto *= _fonte.Height;
        }

        #endregion

        #endregion
        */
    }
}