using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Dtos.nsAmbiente;
using MORM.Servico.Interfaces.nsAmbiente;

namespace MORM.Servico.Services.nsAmbiente
{
    public class AmbienteService : AbstractService<Ambiente>, IAmbienteService
    {
        public AmbienteService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        public ValidarAmbienteDto.Retorno Validar(ValidarAmbienteDto.Envio dto)
        {
            return new ValidarAmbienteDto.Retorno
            {
                Ambiente = new Ambiente(),
            };
        }
    }
}