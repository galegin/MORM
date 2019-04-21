using MORM.Apresentacao.Comps.ViewsModel;
using System.Threading;

namespace MORM.Apresentacao.Comps
{
    public partial class LoadingBox : AbstractWindow
    {
        public LoadingBox() : base()
        {
            InitializeComponent();
            SetPositionInitial();
            DataContext = new LoadingBoxViewModel();
        }

        public void SetMensagem(string mensagem)
        {
            (DataContext as LoadingBoxViewModel).Mensagem = mensagem; 
        }
    }

    public static class LoadingBoxExtensions
    {
        private static LoadingBox _loadingBox;

        public static LoadingBox LoadingBox => _loadingBox ?? (_loadingBox = new LoadingBox());

        public static void OpenLoadingBox(this string mensagem)
        {
            LoadingBox.Dispatcher.Invoke(() =>
            {
                LoadingBox.SetMensagem(mensagem);
                LoadingBox.Show();
                LoadingBox.Activate();
                LoadingBox.Focus();
            });
        }

        public static void ProgressLoadingBox(this string mensagem, int qtde, int item)
        {
            CloseLoadingBox();
            var progresso = (item * 100) / qtde;
            OpenLoadingBox($"{mensagem} {item} de {qtde} / {progresso} %");
        }

        public static void CloseLoadingBox()
        {
            if (_loadingBox != null)
            {
                LoadingBox.Dispatcher.Invoke(() =>
                {
                    LoadingBox.Close();
                    _loadingBox = null;
                });
            }
        }

        public static void SplashingBox(this string mensagem, int tempo = 1000)
        {
            OpenLoadingBox(mensagem);
            Thread.Sleep(tempo);
            CloseLoadingBox();
        }
    }
}