using MaterialDesignThemes.Wpf;
using MORM.CrossCutting;
using System;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public class TituloSistemaViewModel : AbstractViewModel
    {
        #region variaveis
        private PackIconKind _packIconKindMenu = PackIconKind.HamburgerMenu;
        private PackIconKind _packIconKindMinimizar = PackIconKind.WindowMinimize;
        private PackIconKind _packIconKindFechar = PackIconKind.WindowClose;
        private IInformacaoSistema _informacaoSistema;
        private string _nomeEmpresa;
        private string _nomeTerminal;
        private string _nomeUsuario;
        private Image _imagemUsuario;
        private string _nomeSistema;
        private string _dataSistema;
        #endregion

        #region propriedades
        public PackIconKind PackIconKindMenu
        {
            get => _packIconKindMenu;
            set => SetField(ref _packIconKindMenu, value);
        }
        public PackIconKind PackIconKindMinimizar
        {
            get => _packIconKindMinimizar;
            set => SetField(ref _packIconKindMinimizar, value);
        }
        public PackIconKind PackIconKindFechar
        {
            get => _packIconKindFechar;
            set => SetField(ref _packIconKindFechar, value);
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
        public AbstractTimer Timer { get; }
        #endregion

        #region comandos
        public ExibirMenuLateral ExibirMenuLateral { get; }
        public FecharCommand FecharTela { get; }
        public MinimizarCommand MinimizarTela { get; }
        #endregion

        #region construtores
        public TituloSistemaViewModel(IInformacaoSistema informacaoSistema)
        {
            InformacaoSistema = informacaoSistema ?? throw new ArgumentNullException(nameof(informacaoSistema));
            ExibirMenuLateral = new ExibirMenuLateral();
            FecharTela = new FecharCommand();
            MinimizarTela = new MinimizarCommand();
            NomeSistema = AppDomain.CurrentDomain.FriendlyName;
            Timer = new AbstractTimer(SetarDataSistema);
        }
        #endregion

        #region metodos
        protected void SetarDataSistema(object sender) =>
            DataSistema = DateTime.Now.ToString("dd/MM\nHH:mm");

        public void SetarIsExibirMenuLateral()
        {
            TelaUtils.Instance.SetarIsExibirMenuLateral();
        }
        #endregion
    }
}