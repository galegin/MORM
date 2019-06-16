using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Bairro")]
    public class BairroController : AbstractController<Bairro>
    {
        public BairroController(IBairroApiService bairroApiService) : base(bairroApiService)
        {
        }
    }
}