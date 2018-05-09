using System.Collections.Generic;

namespace PhonebookApp.Models
{
    public class PhonebookRecord
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surame { get; set; }

        public string Patronymic { get; set; }

        public List<string> PhoneNumbers { get; set; }
    }
}
