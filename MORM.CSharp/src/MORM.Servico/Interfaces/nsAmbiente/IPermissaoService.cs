using MORM.Dominio.Entidades;
using MORM.Dtos.nsAmbiente;

namespace MORM.Servico.Interfaces.nsAmbiente
{
    public interface IPermissaoService : IAbstractService<Permissao>
    {
        bool VerificarPermissao(VerificarPermissaoDto.Envio dto);
    }
}