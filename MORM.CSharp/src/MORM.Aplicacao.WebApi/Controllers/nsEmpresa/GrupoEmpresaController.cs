using System.Web.Http;
using MORM.CrossCutting;
using MORM.Servico;

namespace MORM.Aplicacao.WebApi
{
    [RoutePrefix("api/GrupoEmpresa")]
    public class GrupoEmpresaController : AbstractController<GrupoEmpresa>
    {
        private readonly IGrupoEmpresaAppService _grupoEmpresaAppService;

        public GrupoEmpresaController(IGrupoEmpresaAppService grupoEmpresaAppService) : base(grupoEmpresaAppService)
        {
            _grupoEmpresaAppService = grupoEmpresaAppService;
        }
    }
}