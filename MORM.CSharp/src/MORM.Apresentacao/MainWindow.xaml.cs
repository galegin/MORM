using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus;
using MORM.Apresentacao.ViewsModel;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public partial class MainWindow : AbstractWindow, IMainWindow
    {
        #region construtores
        public MainWindow(
            ITituloSistema tituloSistema, 
            IMenuLateral menuLateral) : base()
        {
            InitializeComponent();
            IsPrincipal = true;
            Loaded += (s, e) => LoadingBoxExtensions.SplashingBox("Inicializando...");
            SetPositionInitial();
            DataContext = new MainWindowViewModel(tituloSistema, menuLateral);
        }
        #endregion

        #region metodos
        public void Navegar(object sender)
        {
            (DataContext as MainWindowViewModel).Corpo = sender as UserControl;
        }
        public void SetarIsExibirMenuLateral(bool? flag = null)
        {
            (DataContext as MainWindowViewModel).MenuLateral.SetarIsExibirMenuLateral(flag);
        }
        protected override bool PreExecute(object parameter)
        {
            var retorno = TelaUtils.Instance.MainLogin.Execute(parameter) as string;
            return !string.IsNullOrWhiteSpace(retorno);
        }
        #endregion
    }
}