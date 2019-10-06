using MORM.CrossCutting;

namespace MORM.Servico
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