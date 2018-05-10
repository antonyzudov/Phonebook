using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhonebookApp.Models;
using System.Collections.Generic;
using PhonebookApp.Helpers;
using System.Linq;

namespace PhonebookApp.Tests
{
    [TestClass]
    public class PhonebookRecordMapperTests
    {
        [TestMethod]
        [Description("Имя, отчетство и фамилию разделять пробелами")]
        public void MapToClientData_IfAllNames_ThreeWords()
        {
            var model = new PhonebookRecord
            {
                Name = "Сара",
                Patronymic = "Джессика",
                Surname = "Паркер" 
            };

            var actual = PhonebookRecordMapper.MapToClientData(model);

            Assert.AreEqual("Сара Джессика Паркер", actual.FullName);
        }

        [TestMethod]
        [Description("Если в номере 6 цифр, формат хх-хх-хх")]
        public void MapToClientData_IfSixDigits_CityPhone()
        {
            var model = new PhonebookRecord
            {
                PhoneNumbers = new List<string> { "123456" }
            };

            var actual = PhonebookRecordMapper.MapToClientData(model);

            Assert.AreEqual("12-34-56", actual.PhoneNumbers.FirstOrDefault());
        }

        [TestMethod]
        [Description("Если в номере 1 цифр, формат x-xxx-xхх-хх-хх")]
        public void MapToClientData_IfElevenDigits_MobilePhone()
        {
            var model = new PhonebookRecord
            {
                PhoneNumbers = new List<string> { "81234567890" }
            };

            var actual = PhonebookRecordMapper.MapToClientData(model);

            Assert.AreEqual("8-123-456-78-90", actual.PhoneNumbers.FirstOrDefault());
        }
    }
}
