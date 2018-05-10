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

        public static PhonebookRecordClientData MapToClientData(PhonebookRecord model)
        {
            return new PhonebookRecordClientData
            {
                Id = model.Id,
                FullName = GetFullName(model),
                PhoneNumbers = model.PhoneNumbers?.Select(GetFormattedPhoneNumber).ToList() 
                    ?? new List<string>()
            };
        }

        private static string GetFullName(PhonebookRecord model)
        {
            if (!string.IsNullOrEmpty(model.Patronymic))
            {
                return $"{model.Name} {model.Patronymic} {model.Surname}";
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                return $"{model.Name} {model.Surname}";
            }

            return $"{model.Surname}";
        }

        private static string GetFormattedPhoneNumber(string number)
        {
            if (number.Count() == 6)
            {
                return $"{number[0]}{number[1]}-{number[2]}{number[3]}-{number[4]}{number[5]}";
            }

            if (number.Count() == 11)
            {
                var prefix = $"{number[0]}-{number[1]}{number[2]}{number[3]}";
                var mainPart = $"{number[4]}{number[5]}{number[6]}-{number[7]}{number[8]}-{number[9]}{number[10]}";

                return $"{prefix}-{mainPart}";
            }

            return number;
        }
    }
}