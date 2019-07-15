using MORM.Dominio.Entidades;
using MORM.Servico.Models;

namespace MORM.Servico.Interfaces
{
    public interface IAmbienteAppService : IAbstractAppService<Ambiente>
    {
        ValidarAmbienteDto.Retorno Validar(ValidarAmbienteDto.Envio dto);
    }
}