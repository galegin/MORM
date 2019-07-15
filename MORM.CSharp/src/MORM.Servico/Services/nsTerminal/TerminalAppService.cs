using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class TerminalAppService : AbstractAppService<Terminal>, ITerminalAppService
    {
        public TerminalAppService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}