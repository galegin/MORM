using System.Web.Http;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : AbstractController<Empresa>
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresaController(IEmpresaAppService empresaAppService) : base(null)
        {
            _empresaAppService = empresaAppService;
        }
    }
}