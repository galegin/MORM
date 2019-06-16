using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TerminalService : AbstractService<Terminal>, ITerminalService
    {
        public TerminalService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}