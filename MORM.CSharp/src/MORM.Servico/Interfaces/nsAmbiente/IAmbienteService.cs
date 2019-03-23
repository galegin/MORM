using MORM.Dominio.Entidades;
using MORM.Dtos.nsAmbiente;

namespace MORM.Servico.Interfaces.nsAmbiente
{
    public interface IAmbienteService : IAbstractService<Ambiente>
    {
        AmbienteDto.ValidarAcessoRetorno ValidarAcesso(AmbienteDto.ValidarAcesso dto);
    }
}