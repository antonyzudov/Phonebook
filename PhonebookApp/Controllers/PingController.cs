using System.Web.Http;

namespace PhonebookApp.Controllers
{
    public class PingController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}
