using MORM.Repositorio.Uow;
using MORM.Utilidade.Entidades;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Services.nsAmbiente
{
    //-- galeg - 26/05/2018 17:33:51
    public class AmbienteService : AbstractService<Ambiente>, IAmbienteService
    {
        public AmbienteService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        public AmbienteService(IAmbiente ambiente) : base(ambiente)
        {
        }
    }
}