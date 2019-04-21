using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces.nsAmbiente;
using System.Web.Http;

namespace MORM.WebApi.Controllers.nsAmbiente
{
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : AbstractController<Empresa>
    {
        public EmpresaController(IEmpresaService empresaService) : base(empresaService)
        {
        }
    }
}