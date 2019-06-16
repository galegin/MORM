using MORM.Dominio.Entidades;
using MORM.Dtos;

namespace MORM.Servico.Interfaces
{
    public interface IAmbienteService : IAbstractService<Ambiente>
    {
        ValidarAmbienteDto.Retorno Validar(ValidarAmbienteDto.Envio dto);
    }
}