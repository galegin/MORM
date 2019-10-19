using MORM.CrossCutting;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public partial class MainLogin : AbstractWindow, IMainLogin
    {
        private LoginViewModel _vm => DataContext as LoginViewModel;

        public MainLogin()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            IsPrincipal = false;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (_vm.Model as LoginModel).Senha = (sender as PasswordBox).Password;
        }

        public override bool IsConfirmado
        {
            get => _vm.IsConfirmado;
            protected set => base.IsConfirmado = value;
        }

        protected override bool PreConfirmado(object parameter) => 
            !string.IsNullOrWhiteSpace(AbstractApiConsumer.TokenInterno);
        protected override object PosConfirmado(object parameter) => 
            AbstractApiConsumer.TokenInterno;
        protected override object PosExecute(object parameter) =>
            _vm.Token;
    }
}