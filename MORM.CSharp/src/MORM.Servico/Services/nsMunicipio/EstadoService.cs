using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class EstadoService : AbstractService<Estado>, IEstadoService
    {
        public EstadoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}