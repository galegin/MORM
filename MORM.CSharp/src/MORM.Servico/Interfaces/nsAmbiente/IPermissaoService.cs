using MORM.Dominio.Entidades;
using MORM.Dtos;

namespace MORM.Servico.Interfaces
{
    public interface IPermissaoService : IAbstractService<Permissao>
    {
        bool VerificarPermissao(VerificarPermissaoDto.Envio dto);
    }
}