using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces.nsAmbiente;

namespace MORM.Servico.Services.nsAmbiente
{
    public class TerminalService : AbstractApiService<Terminal>, ITerminalService
    {
        public TerminalService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}