using System.Drawing;

namespace MORM.Infra.CrossCutting
{
    public class AjusteImagem
    {
        #region Metodos
        public static void RedimensionarImagem(Image imagemLogo, out int alturaImagem, out int larguraImagem)
        {
            alturaImagem = 0;
            larguraImagem = 0;

            if (imagemLogo == null)
                return;

            alturaImagem = imagemLogo.Height;
            larguraImagem = imagemLogo.Width;

            while (alturaImagem > 300 || larguraImagem > 300)
            {
                int novaAltura, novaLargura = 0;

                if (alturaImagem > 300)
                {
                    novaAltura = 300;
                    novaLargura = novaAltura * larguraImagem / alturaImagem;
                    alturaImagem = novaAltura;
                    larguraImagem = novaLargura;
                }

                if (larguraImagem > 300)
                {
                    novaLargura = 300;
                    novaAltura = novaLargura * alturaImagem / larguraImagem;
                    alturaImagem = novaAltura;
                    larguraImagem = novaLargura;
                }
            }
        }
        #endregion
    }
}