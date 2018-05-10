using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhonebookApp.Business;
using PhonebookApp.Business.Abstract.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhonebookApp.Tests
{
    [TestClass]
    public class PhonebookRecordBusinessModelGeneratorTests
    {
        private static PhonebookRecordBusinessModelGenerator generator;

        [TestInitialize]
        public void SetUp()
        {
            generator = new PhonebookRecordBusinessModelGenerator();
        }

        [TestMethod]
        [Description("Если в Fullname одно слово, то оно должно попасть в имя, а фамилия и отчетство должны остаться пустыми")]
        public void Generate_IfOneWord_OnlyName()
        {
            var saveRequest = new PhonebookRecordSaveRequest
            {
                Fullname = "Бонд"
            };

            var actual = generator.Generate(saveRequest);

            Assert.AreEqual(saveRequest.Fullname, actual.Surname);
            Assert.IsNull(actual.Name);
            Assert.IsNull(actual.Patronymic);
        }

        [TestMethod]
        [Description("Если в Fullname два слова, то они должно попасть в имя и фамилию, а отчетство должно остаться пустым")]
        public void Generate_IfTwoWords_NameAndSurname()
        {
            var saveRequest = new PhonebookRecordSaveRequest
            {
                Fullname = "Джеймс Бонд"
            };

            var actual = generator.Generate(saveRequest);

            Assert.AreEqual("Джеймс", actual.Name);
            Assert.AreEqual("Бонд", actual.Surname);
            Assert.IsNull(actual.Patronymic);
        }

        [TestMethod]
        [Description("Если в Fullname больше двух слов, то последнее должно попасть в фамилию, предпоследнее в отчество, а остальные в имя")]
        public void Generate_IfManyWords_AllNames()
        {
            var saveRequest = new PhonebookRecordSaveRequest
            {
                Fullname = "Кристина Мария Фаустовна Агилера"
            };

            var actual = generator.Generate(saveRequest);

            Assert.AreEqual("Кристина Мария", actual.Name);
            Assert.AreEqual("Фаустовна", actual.Patronymic);
            Assert.AreEqual("Агилера", actual.Surname);
        }

        [TestMethod]
        [Description("Если в номере только цифры, оставить его без изменений")]
        public void Generate_IfDigitsOnly_TakeAll()
        {
            var saveRequest = new PhonebookRecordSaveRequest
            {
                PhoneNumbers = new List<string> { "123456789" } 
            };

            var actual = generator.Generate(saveRequest);

            Assert.AreEqual("123456789", actual.PhoneNumbers.FirstOrDefault());
        }

        [TestMethod]
        [Description("Если номере не только цифры, удалить лишние символы")]
        public void Generate_IfFormatted_TakeDigits()
        {
            var saveRequest = new PhonebookRecordSaveRequest
            {
                PhoneNumbers = new List<string> { "8 (123) 456-78-90" }
            };

            var actual = generator.Generate(saveRequest);

            Assert.AreEqual("81234567890", actual.PhoneNumbers.FirstOrDefault());
        }
    }
}
