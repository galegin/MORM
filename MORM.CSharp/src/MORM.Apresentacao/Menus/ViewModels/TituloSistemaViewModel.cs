using MaterialDesignThemes.Wpf;
using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus.Commands;
using MORM.Apresentacao.ViewModels;
using MORM.Dominio.Interfaces;
using System;
using System.Windows.Controls;

namespace MORM.Apresentacao.Menus.ViewModels
{
    public class TituloSistemaViewModel : AbstractViewModel
    {
        #region construtores
        public TituloSistemaViewModel(
            IInformacaoSistema informacaoSistema,
            IMainWindowExec mainWindowExec)
        {
            InformacaoSistema = informacaoSistema ?? throw new ArgumentNullException(nameof(informacaoSistema));
            MainWindowExec = mainWindowExec ?? throw new ArgumentNullException(nameof(mainWindowExec));
            NomeSistema = AppDomain.CurrentDomain.FriendlyName;
            SetarTimer(SetarDataSistema);
        }
        #endregion

        #region variaveis
        private PackIconKind _packIconKindMenu = PackIconKind.HamburgerMenu;
        private IInformacaoSistema _informacaoSistema;
        private IMainWindowExec _mainWindowExec;
        private string _nomeEmpresa;
        private string _nomeTerminal;
        private string _nomeUsuario;
        private Image _imagemUsuario;
        private string _nomeSistema;
        private string _dataSistema;
        private AbstractTimer _timer;
        #endregion

        #region propriedades
        public PackIconKind PackIconKindMenu
        {
            get => _packIconKindMenu;
            set => SetField(ref _packIconKindMenu, value);
        }
        public IInformacaoSistema InformacaoSistema
        {
            get => _informacaoSistema;
            set
            {
                SetField(ref _informacaoSistema, value);
                NomeEmpresa = $"{_informacaoSistema.Empresa.Id_Empresa} {_informacaoSistema.Empresa.Ds_Empresa}";
                NomeTerminal = $"{_informacaoSistema.Terminal.Id_Terminal} {_informacaoSistema.Terminal.Ds_Terminal}";
                NomeUsuario = $"{_informacaoSistema.Usuario.Id_Usuario} {_informacaoSistema.Usuario.Nm_Usuario}";
            }
        }
        public IMainWindowExec MainWindowExec
        {
            get => _mainWindowExec;
            set => SetField(ref _mainWindowExec, value);
        }
        public string NomeEmpresa
        {
            get => _nomeEmpresa;
            set => SetField(ref _nomeEmpresa, value);
        }
        public string NomeUsuario
        {
            get => _nomeUsuario;
            set => SetField(ref _nomeUsuario, value);
        }
        public Image ImageUsuario
        {
            get => _imagemUsuario;
            set => SetField(ref _imagemUsuario, value);
        }
        public string NomeTerminal
        {
            get => _nomeTerminal;
            set => SetField(ref _nomeTerminal, value);
        }
        public string NomeSistema
        {
            get => _nomeSistema;
            set => SetField(ref _nomeSistema, value);
        }
        public string DataSistema
        {
            get => _dataSistema;
            set => SetField(ref _dataSistema, value);
        }
        #endregion

        #region comandos
        public ExibirMenuLateral ExibirMenuLateral { get; } = new ExibirMenuLateral();
        #endregion

        #region metodos protegidos
        protected void SetarTimer(OnTimerExecute onTimerExecute)
        {
            if (_timer == null)
                _timer = new AbstractTimer(onTimerExecute);
        }
        protected void IniciarTimer() => _timer?.Iniciar();
        protected void PararTimer() => _timer?.Parar();
        protected void SetarDataSistema(object sender) => DataSistema = DateTime.Now.ToString("dd/MM\nHH:mm");
        #endregion

        #region metodos publicos
        public void SetarIsExibirMenuLateral()
        {
            MainWindowExec.SetarIsExibirMenuLateral();
        }
        #endregion
    }
}