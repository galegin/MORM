using MORM.Utils.Classes;

namespace MORM.Apresentacao.Comps
{
    /// <summary>
    /// Interação lógica para ucMensagemLog.xam
    /// </summary>
    public partial class MensagemLog : AbstractWindow
    {
        public MensagemLog() : base()
        {
            InitializeComponent();
            Loaded += MensagemLog_Loaded;
            SetPositionInitial();
            SetDataContext();
        }

        private void MensagemLog_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ConteudoMensagem = LoggerMem.Mensagem;
        }

        private string _conteudoMensagem;
        public string ConteudoMensagem
        {
            get => _conteudoMensagem;
            set => SetField(ref _conteudoMensagem, value);
        }
    }

    public static class MensagemLogExtensions
    {
        public static void ShowMensagemLog()
        {
            using (var mensagemLog = new MensagemLog())
            {
                mensagemLog.ShowDialog();
            }
        }
    }
}