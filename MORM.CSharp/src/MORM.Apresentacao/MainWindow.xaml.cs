using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus;
using MORM.Apresentacao.ViewsModel;
using System.Windows;
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
            Loaded += MainWindow_Loaded;
            SetPositionInitial();
            DataContext = new MainWindowViewModel(tituloSistema, menuLateral);
        }
        #endregion

        #region metodos
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingBoxExtensions.SplashingBox("Inicializando...");
        }
        public void Navegar(object sender)
        {
            (DataContext as MainWindowViewModel).Corpo = sender as UserControl;
        }
        public void SetarIsExibirMenuLateral(bool? flag = null)
        {
            (DataContext as MainWindowViewModel).MenuLateral.SetarIsExibirMenuLateral(flag);
        }
        #endregion
    }
}