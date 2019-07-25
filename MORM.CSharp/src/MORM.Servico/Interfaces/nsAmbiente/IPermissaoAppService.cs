using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Models;

namespace MORM.Servico.Interfaces
{
    public interface IPermissaoAppService : IAbstractAppService<Permissao>
    {
        bool VerificarPermissao(VerificarPermissaoInModel model);
    }
}