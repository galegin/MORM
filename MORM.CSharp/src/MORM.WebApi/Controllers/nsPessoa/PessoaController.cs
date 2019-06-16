using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Pessoa")]
    public class PessoaController : AbstractController<Pessoa>
    {
        public PessoaController(IPessoaApiService pessoaApiService) : base(pessoaApiService)
        {
        }
    }
}