using MORM.Servico.Models;

namespace MORM.Servico.Interfaces
{
    public interface IPermissaoAppService
    {
        bool VerificarPermissao(VerificarPermissaoInModel model);
    }
}