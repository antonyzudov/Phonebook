using PhonebookApp.Business.Abstract;
using System;
using PhonebookApp.Business.Abstract.Models;
using PhonebookApp.Models;
using System.Linq;

namespace PhonebookApp.Business
{
    public class PhonebookRecordBusinessModelGenerator : IPhonebookRecordBusinessModelGenerator
    {
        public PhonebookRecord Generate(PhonebookRecordSaveRequest saveRequest)
        {
            char[] charSeparators = new char[] { ',', ' ', '.' };
            var words = saveRequest.Fullname.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (words.Count <= 1)
            {
                return new PhonebookRecord
                {
                    Id = saveRequest.Id.GetValueOrDefault(0),
                    Surame = words.FirstOrDefault(),
                };
            }

            if (words.Count == 2)
            {
                return new PhonebookRecord
                {
                    Id = saveRequest.Id.GetValueOrDefault(0),
                    Name = words.First(),
                    Surame = words.Last()
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
                Surame = surname
            };
        }
    }
}
