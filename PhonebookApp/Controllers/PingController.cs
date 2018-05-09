using System.Net.Http;
using System.Web.Http;
using PhonebookApp.Business.Abstract;
using System.Threading.Tasks;

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
        public async Task<HttpResponseMessage> Ping()
        {
            var result = await service.PingAsync().ConfigureAwait(false);

            return Request.CreateResponse(result);
        }
    }
}
