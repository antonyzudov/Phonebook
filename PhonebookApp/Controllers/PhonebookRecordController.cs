using PhonebookApp.Business.Abstract;
using PhonebookApp.Helpers;
using PhonebookApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhonebookApp.Controllers
{
    public class PhonebookRecordController : ApiController
    {
        private readonly IPhonebookRecordService service;

        public PhonebookRecordController(IPhonebookRecordService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<int> Save([FromBody] PhonebookRecordSaveRequestClientData clientData)
        {
            PhonebookValidator.ValidateSaveRequest(clientData);

            var saveRequest = PhonebookRecordMapper.MapToSaveRequest(clientData);
            var result = await service.SaveAsync(saveRequest).ConfigureAwait(false);
            return result;
        }

        [HttpGet]
        public async Task<PhonebookRecordClientData> Get()
        {
            var model = await service.GetAsync(1).ConfigureAwait(false);
            return PhonebookRecordMapper.MapToClientData(model);
        }
    }
}
