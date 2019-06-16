using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Produto")]
    public class ProdutoController : AbstractController<Produto>
    {
        public ProdutoController(IProdutoApiService produtoApiService) : base(produtoApiService)
        {
        }
    }
}