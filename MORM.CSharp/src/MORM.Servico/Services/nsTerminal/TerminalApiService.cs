using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TerminalApiService : AbstractApiService<Terminal>, ITerminalApiService
    {
        public TerminalApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}