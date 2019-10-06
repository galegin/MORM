using System.Web.Http;
using MORM.CrossCutting;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.WebApi
{
    [RoutePrefix("api/Terminal")]
    public class TerminalController : AbstractController<Terminal>
    {
        private readonly ITerminalAppService _terminalAppService;

        public TerminalController(ITerminalAppService terminalAppService) : base(terminalAppService)
        {
            _terminalAppService = terminalAppService;
        }
    }
}