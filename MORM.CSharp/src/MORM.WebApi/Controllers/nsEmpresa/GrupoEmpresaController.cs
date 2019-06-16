using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/GrupoEmpresa")]
    public class GrupoEmpresaController : AbstractController<GrupoEmpresa>
    {
        public GrupoEmpresaController(IGrupoEmpresaApiService grupoEmpresaApiService) : base(grupoEmpresaApiService)
        {
        }
    }
}