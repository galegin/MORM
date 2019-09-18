using System.Web.Http;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Terminal")]
    public class TerminalController : AbstractController<Terminal>
    {
        private readonly ITerminalAppService _terminalAppService;

        public TerminalController(ITerminalAppService terminalAppService) : base(null)
        {
            _terminalAppService = terminalAppService;
        }
    }
}