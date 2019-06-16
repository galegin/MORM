using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Terminal")]
    public class TerminalController : AbstractController<Terminal>
    {
        public TerminalController(ITerminalApiService terminalApiService) : base(terminalApiService)
        {
        }
    }
}