using MORM.Servico.Models;

namespace MORM.Servico.Interfaces
{
    public interface IAmbienteAppService
    {
        object Validar(ValidarAmbienteInModel model);
    }
}