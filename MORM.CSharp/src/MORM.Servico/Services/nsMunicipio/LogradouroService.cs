using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class LogradouroService : AbstractService<Logradouro>, ILogradouroService
    {
        public LogradouroService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}