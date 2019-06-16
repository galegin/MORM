using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Municipio")]
    public class MunicipioController : AbstractController<Municipio>
    {
        public MunicipioController(IMunicipioApiService municipioApiService) : base(municipioApiService)
        {
        }
    }
}