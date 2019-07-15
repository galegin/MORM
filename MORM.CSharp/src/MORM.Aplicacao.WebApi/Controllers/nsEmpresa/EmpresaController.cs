using System.Web.Http;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : AbstractController<Empresa>
    {
        public EmpresaController(IEmpresaAppService empresaAppService) : base(empresaAppService)
        {
        }
    }
}