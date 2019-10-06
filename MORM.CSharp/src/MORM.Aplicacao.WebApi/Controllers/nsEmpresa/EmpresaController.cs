using System.Web.Http;
using MORM.CrossCutting;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.WebApi
{
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : AbstractController<Empresa>
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresaController(IEmpresaAppService empresaAppService) : base(empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }
    }
}