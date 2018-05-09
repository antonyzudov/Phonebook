using PhonebookApp.Models;
using System;

namespace PhonebookApp.Helpers
{
    public static class PhonebookValidator
    {
        public static void ValidateSaveRequest(PhonebookRecordSaveRequestClientData clientData)
        {
            if (!clientData.Id.HasValue && string.IsNullOrWhiteSpace(clientData.Fullname))
            {
                throw new ArgumentException("Empty name is not allowed");
            }
        }
    }
}