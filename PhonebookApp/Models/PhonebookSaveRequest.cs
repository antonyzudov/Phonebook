using System.Collections.Generic;

namespace PhonebookApp.Models
{
    public class PhonebookRecordSaveRequestClientData
    {
        public int? Id { get; set; } 

        public string Fullname { get; set; }

        public List<string> PhoneNumbers { get; set; }
    }
}