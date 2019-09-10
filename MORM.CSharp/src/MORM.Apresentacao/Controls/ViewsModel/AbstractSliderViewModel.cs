using MORM.Apresentacao.ViewsModel;
using MORM.CrossCutting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MORM.Apresentacao.Controls.ViewsModel
{
    public class AbstractSliderViewModel : AbstractViewModel
    {
        #region variaveis
        private List<AbstractImage> _images;
        private AbstractImage _imageSelecionada;
        private int _sequencia;
        #endregion

        #region propriedades
        public List<AbstractImage> Images
        {
            get => _images;
            set => SetField(ref _images, value);
        }
        public AbstractImage ImageSelecionada
        {
            get => _imageSelecionada;
            set => SetField(ref _imageSelecionada, value);
        }
        public int UltimaSequencia => Images.Count - 1;
        public int Sequencia
        {
            get => _sequencia;
            set
            {
                value = value < 0 ? 0 
                    : value > UltimaSequencia ? UltimaSequencia 
                    : value;
                SetField(ref _sequencia, value);
                ImageSelecionada = Images.Count > 0 ? Images[Sequencia] : null;
            }
        }
        #endregion

        #region contrutores
        public AbstractSliderViewModel()
        {
            Images = new List<AbstractImage>();
            CarregarImagens();
        }
        #endregion

        #region metodos
        public void CarregarImagens()
        {
            var pastaImagem = CaminhoPadrao.GetPathSubPasta(subPasta: "Images");
            if (!Directory.Exists(pastaImagem))
                return;

            var extensoes = new[] { "*.png", "*.jpg" };
            foreach(var extensao in extensoes)
                ArquivoDiretorio.GetListaDeArquivo(pastaImagem, extensao)
                    .OrderBy(x => x)
                    .ToList()
                    .ForEach(arquivo =>
                    {
                        Images.Add(new AbstractImage(arquivo));
                    });

            Sequencia = 0;
        }
        public void Primeira() => Sequencia = 0;
        public void Anterior() => Sequencia--;
        public void Proxima() => Sequencia++;
        public void Ultima() => Sequencia = UltimaSequencia;
        public void SetarProxima()
        {
            if (UltimaSequencia == 1)
                return;

            if (Sequencia >= UltimaSequencia)
                Primeira();
            else
                Proxima();
        }
        #endregion
    }
}