using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/ProdutoBarra")]
    public class ProdutoBarraController : AbstractController<ProdutoBarra>
    {
        public ProdutoBarraController(IProdutoBarraApiService produtoBarraApiService) : base(produtoBarraApiService)
        {
        }
    }
}