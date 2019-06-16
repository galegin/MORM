using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Operacao")]
    public class OperacaoController : AbstractController<Operacao>
    {
        public OperacaoController(IOperacaoApiService operacaoApiService) : base(operacaoApiService)
        {
        }
    }
}