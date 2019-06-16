using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class PaisService : AbstractService<Pais>, IPaisService
    {
        public PaisService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}