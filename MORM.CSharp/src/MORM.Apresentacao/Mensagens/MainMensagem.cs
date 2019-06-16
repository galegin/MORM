using System.Windows;

namespace MORM.Apresentacao.Mensagens
{
    public class MainMensagem : IMainMensagem
    {
        public void MensagemAviso(string conteudo)
        {
            MessageBox.Show(conteudo, "Informação", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void MensagemErro(string conteudo)
        {
            MessageBox.Show(conteudo, "Informação", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void MensagemInfo(string conteudo)
        {
            MessageBox.Show(conteudo, "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public bool? ConfirmacaoAviso(string conteudo)
        {
            return MessageBox.Show(conteudo, "Confirmação", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes;
        }

        public bool? ConfirmacaoErro(string conteudo)
        {
            return MessageBox.Show(conteudo, "Confirmação", MessageBoxButton.YesNoCancel, MessageBoxImage.Error) == MessageBoxResult.Yes;
        }

        public bool? ConfirmacaoInfo(string conteudo)
        {
            return MessageBox.Show(conteudo, "Confirmação", MessageBoxButton.YesNoCancel, MessageBoxImage.Information) == MessageBoxResult.Yes;
        }
    }
}