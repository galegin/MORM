using MORM.Dominio.Entidades;
using MORM.Dtos.nsAmbiente;

namespace MORM.Servico.Interfaces.nsAmbiente
{
    public interface IAmbienteService : IAbstractService<Ambiente>
    {
        ValidarAmbienteDto.Retorno Validar(ValidarAmbienteDto.Envio dto);
    }
}