using PhonebookApp.Business.Abstract;
using System;
using PhonebookApp.Business.Abstract.Models;
using PhonebookApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace PhonebookApp.Business
{
    public class PhonebookRecordBusinessModelGenerator : IPhonebookRecordBusinessModelGenerator
    {
        public PhonebookRecord Generate(PhonebookRecordSaveRequest saveRequest)
        {
            var phoneNumbers = saveRequest.PhoneNumbers?.Select(x => ParseNumber(x)).ToList() ?? new List<string>();

            char[] charSeparators = new char[] { ',', ' ', '.' };
            var words = saveRequest.Fullname?.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).ToList() 
                ?? new List<string>();

            if (words.Count <= 1)
            {
                return new PhonebookRecord
                {
                    Id = saveRequest.Id.GetValueOrDefault(0),
                    Surame = words.FirstOrDefault(),
                    PhoneNumbers = phoneNumbers
                };
            }

            if (words.Count == 2)
            {
                return new PhonebookRecord
                {
                    Id = saveRequest.Id.GetValueOrDefault(0),
                    Name = words.First(),
                    Surame = words.Last(),
                    PhoneNumbers = phoneNumbers
                };
            }

            var surname = words.LastOrDefault();
            words.Remove(surname);            

            var patronymic = words.LastOrDefault();
            words.Remove(patronymic);

            return new PhonebookRecord
            {
                Id = saveRequest.Id.GetValueOrDefault(0),
                Name = string.Join(" ", words),
                Patronymic = patronymic,
                Surame = surname,
                PhoneNumbers = phoneNumbers
            };
        }

        private string ParseNumber(string number)
        {
            return string.Join("", number.Where(c => char.IsDigit(c)));
        }
    }
}
