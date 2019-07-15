using MORM.Dominio.Entidades;
using MORM.Servico.Models;

namespace MORM.Servico.Interfaces
{
    public interface IPermissaoAppService : IAbstractAppService<Permissao>
    {
        bool VerificarPermissao(VerificarPermissaoDto.Envio dto);
    }
}