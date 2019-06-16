using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class LogradouroApiService : AbstractApiService<Logradouro>, ILogradouroApiService
    {
        public LogradouroApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}