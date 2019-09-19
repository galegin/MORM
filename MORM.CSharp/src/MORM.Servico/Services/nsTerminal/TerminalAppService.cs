using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class TerminalAppService : AbstractAppService<Terminal>, ITerminalAppService
    {
        private readonly ITerminalRepository _terminalRepository;

        public TerminalAppService(ITerminalRepository terminalRepository) : base(terminalRepository)
        {
            _terminalRepository = terminalRepository;
        }
    }
}