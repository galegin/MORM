using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus;
using MORM.Apresentacao.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public partial class MainWindow : AbstractWindow, IMainWindow
    {
        #region construtores
        public MainWindow(
            ITituloSistema tituloSistema, 
            IMenuLateral menuLateral, 
            IMainWindowExec mainWindowExec) : base()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            SetPositionInitial();
            mainWindowExec.SetMainWindow(this);
            DataContext = new MainWindowViewModel(tituloSistema, menuLateral, mainWindowExec);
        }
        #endregion

        #region metodos
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingBoxExtensions.SplashingBox("Inicializando...");
        }
        public void Navegar(UserControl userControl)
        {
            (DataContext as MainWindowViewModel).Corpo = userControl;
        }
        public void SetarIsExibirMenuLateral(bool? flag = null)
        {
            (DataContext as MainWindowViewModel).MenuLateral.SetarIsExibirMenuLateral(flag);
        }
        #endregion
    }
}