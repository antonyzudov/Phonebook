using System.Collections.Generic;

namespace PhonebookApp.Models
{
    public class PhonebookRecordClientData
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<string> PhoneNumbers { get; set; }
    }
}