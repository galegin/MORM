using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MORM.Apresentacao.Controls
{
    public class AbstractImage
    {
        #region propriedades
        public string Arquivo { get; private set; }
        public ImageSource Source { get; private set; }
        #endregion

        #region construtores
        public AbstractImage(string arquivo = null)
        {
            Arquivo = arquivo;
            CarregarArquivo(arquivo);
        }
        #endregion

        #region metodos
        public void CarregarArquivo(string arquivo)
        {
            ImageSource source = null;
            if (!string.IsNullOrWhiteSpace(arquivo) && File.Exists(arquivo))
            {
                Uri resourceUri = new Uri(arquivo, UriKind.Relative);
                source = new BitmapImage(resourceUri);
            }
            Source = source;
        }
        #endregion
    }
}