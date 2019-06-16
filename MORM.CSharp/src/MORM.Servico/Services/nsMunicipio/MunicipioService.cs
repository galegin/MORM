using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class MunicipioService : AbstractService<Municipio>, IMunicipioService
    {
        public MunicipioService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}