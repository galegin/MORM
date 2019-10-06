namespace MORM.Servico
{
    public interface IPermissaoAppService
    {
        bool VerificarPermissao(VerificarPermissaoInModel model);
    }
}