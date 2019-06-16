using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Logradouro")]
    public class LogradouroController : AbstractController<Logradouro>
    {
        public LogradouroController(ILogradouroApiService logradouroApiService) : base(logradouroApiService)
        {
        }
    }
}