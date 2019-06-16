using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/ProdutoSaldo")]
    public class ProdutoSaldoController : AbstractController<ProdutoSaldo>
    {
        public ProdutoSaldoController(IProdutoSaldoApiService produtoSaldoApiService) : base(produtoSaldoApiService)
        {
        }
    }
}