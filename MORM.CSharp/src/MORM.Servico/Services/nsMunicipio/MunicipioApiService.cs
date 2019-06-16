using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class MunicipioApiService : AbstractApiService<Municipio>, IMunicipioApiService
    {
        public MunicipioApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}