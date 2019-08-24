﻿using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls;
using MORM.Apresentacao.Menus;
using MORM.Apresentacao.ViewsModel;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public partial class MainWindow : AbstractWindow, IMainWindow
    {
        #region variaveis
        private MainWindowViewModel _vm => DataContext as MainWindowViewModel;
        #endregion

        #region propriedades
        public AbstractSlider Slider { get; }
        #endregion

        #region construtores
        public MainWindow(
            ITituloSistema tituloSistema, 
            IMenuLateral menuLateral) : base()
        {
            InitializeComponent();
            IsPrincipal = true;
            Loaded += MainWindow_Loaded; // (s, e) => LoadingBoxExtensions.SplashingBox("Inicializando...");
            SetPositionInitial();
            DataContext = new MainWindowViewModel(tituloSistema, menuLateral);
            Slider = new AbstractSlider();
        }
        #endregion

        #region metodos
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingBoxExtensions.SplashingBox("Inicializando...");
            Navegar(null);
        }
        public void Navegar(object sender)
        {
            sender = sender ?? Slider;
            Slider.Timer.Ativo = (sender == Slider);
            _vm.Corpo = sender as UserControl;
        }
        public void SetarIsExibirMenuLateral(bool? flag = null)
        {
            _vm.MenuLateral.SetarIsExibirMenuLateral(flag);
        }
        protected override bool PreExecute(object parameter)
        {
            var retorno = TelaUtils.Instance.MainLogin.Execute(parameter) as string;
            return !string.IsNullOrWhiteSpace(retorno);
        }
        #endregion
    }
}