using System.Net.Http;
using System.Web.Http;
using PhonebookApp.Business.Abstract;

namespace PhonebookApp.Controllers
{
    [RoutePrefix("")]
    public class PingController : ApiController
    {
        private readonly IPingService service;

        public PingController(IPingService service)
        {
            this.service = service;
        }

        [HttpGet]
        public HttpResponseMessage Ping()
        {
            return Request.CreateResponse(service.Ping());
        }
    }
}
