using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/TipoValor")]
    public class TipoValorController : AbstractController<TipoValor>
    {
        public TipoValorController(ITipoValorApiService tipoValorApiService) : base(tipoValorApiService)
        {
        }
    }
}