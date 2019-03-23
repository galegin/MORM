using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Dtos.nsAmbiente;
using MORM.Servico.Interfaces.nsAmbiente;

namespace MORM.Servico.Services.nsAmbiente
{
    public class AmbienteService : AbstractService<Ambiente>, IAmbienteService
    {
        public AmbienteService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        public AmbienteService(IAmbiente ambiente) : base(ambiente)
        {
        }

        public AmbienteDto.ValidarAcessoRetorno ValidarAcesso(AmbienteDto.ValidarAcesso dto)
        {
            throw new System.NotImplementedException();
        }
    }
}