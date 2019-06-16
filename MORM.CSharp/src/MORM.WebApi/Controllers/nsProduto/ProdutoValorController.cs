using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/ProdutoValor")]
    public class ProdutoValorController : AbstractController<ProdutoValor>
    {
        public ProdutoValorController(IProdutoValorApiService produtoValorApiService) : base(produtoValorApiService)
        {
        }
    }
}