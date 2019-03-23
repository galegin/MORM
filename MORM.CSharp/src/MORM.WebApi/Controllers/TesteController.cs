using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MORM.WebApi.Controllers
{
    //[RoutePrefix("api/Teste")]
    public class TesteController : ApiController
    {
        [HttpGet]
        //[Route("Echo")]
        public HttpResponseMessage Echo()
        {
            return Request.CreateResponse(HttpStatusCode.OK, MessageHandler.CreateMessage());
        }
    }
}