using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Login.ViewsModel;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    /// <summary>
    /// Interação lógica para MainLogin.xam
    /// </summary>
    public partial class MainLogin : AbstractWindow, IMainLogin
    {
        public MainLogin()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            IsPrincipal = false;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginViewModel).Model.Senha = (sender as PasswordBox).Password;
        }

        protected override object PosExecute(object parameter)
        {
            return (DataContext as LoginViewModel).Token;
        }
    }
}
