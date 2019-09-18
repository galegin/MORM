using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class TerminalAppService : ITerminalAppService
    {
        private readonly ITerminalRepository _terminalRepository;

        public TerminalAppService(ITerminalRepository terminalRepository)
        {
            _terminalRepository = terminalRepository;
        }
    }
}