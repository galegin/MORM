namespace MORM.Apresentacao
{
    public interface IMainMensagem
    {
        void MensagemAviso(string conteudo);
        void MensagemErro(string conteudo);
        void MensagemInfo(string conteudo);
        bool? ConfirmacaoAviso(string conteudo);
        bool? ConfirmacaoErro(string conteudo);
        bool? ConfirmacaoInfo(string conteudo);
    }
}