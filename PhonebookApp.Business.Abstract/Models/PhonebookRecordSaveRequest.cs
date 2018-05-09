using System.Collections.Generic;

namespace PhonebookApp.Business.Abstract.Models
{
    public class PhonebookRecordSaveRequest
    {
        public int? Id { get; set; }

        public string Fullname { get; set; }

        public List<string> PhoneNumbers { get; set; }
    }
}
