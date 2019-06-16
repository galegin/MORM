using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class BairroApiService : AbstractApiService<Bairro>, IBairroApiService
    {
        public BairroApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}