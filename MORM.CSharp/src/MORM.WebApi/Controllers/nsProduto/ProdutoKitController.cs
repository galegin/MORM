using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/ProdutoKit")]
    public class ProdutoKitController : AbstractController<ProdutoKit>
    {
        public ProdutoKitController(IProdutoKitApiService produtoKitApiService) : base(produtoKitApiService)
        {
        }
    }
}