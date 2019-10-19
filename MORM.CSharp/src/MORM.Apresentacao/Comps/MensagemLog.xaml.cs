using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public partial class MensagemLog : AbstractWindow
    {
        public MensagemLog() : base()
        {
            InitializeComponent();
            Loaded += (s, e) => (DataContext as MensagemLogViewModel).Mensagem = LoggerMem.Mensagem;
            SetPositionInitial();
            DataContext = new MensagemLogViewModel();
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