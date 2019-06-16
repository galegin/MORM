using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class PaisApiService : AbstractApiService<Pais>, IPaisApiService
    {
        public PaisApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}