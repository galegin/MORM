using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Transacao")]
    public class TransacaoController : AbstractController<Transacao>
    {
        public TransacaoController(ITransacaoApiService transacaoApiService) : base(transacaoApiService)
        {
        }
    }
}