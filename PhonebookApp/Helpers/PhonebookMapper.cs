using PhonebookApp.Business.Abstract.Models;
using PhonebookApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhonebookApp.Helpers
{
    public static class PhonebookRecordMapper
    {
        public static PhonebookRecordSaveRequest MapToSaveRequest(PhonebookRecordSaveRequestClientData clientData)
        {
            return new PhonebookRecordSaveRequest
            {
                Id = clientData.Id,
                Fullname = clientData.Fullname,
                PhoneNumbers = clientData.PhoneNumbers?.Select(x => x).ToList() ?? new List<string>()
            };
        }
    }
}