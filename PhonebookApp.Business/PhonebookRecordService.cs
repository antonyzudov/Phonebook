using PhonebookApp.Business.Abstract;
using System.Threading.Tasks;
using PhonebookApp.Business.Abstract.Models;
using Domain.Abstract;
using PhonebookApp.Models;
using System;

namespace PhonebookApp.Business
{
    public class PhonebookRecordService : IPhonebookRecordService
    {
        private readonly IPhonebookRecordBusinessModelGenerator businessModelGenerator;
        private readonly IPhonebookRecordDao dao;

        public PhonebookRecordService(
            IPhonebookRecordBusinessModelGenerator businessModelGenerator,
            IPhonebookRecordDao dao)
        {
            this.businessModelGenerator = businessModelGenerator;
            this.dao = dao;
        }

        public async Task<int> SaveAsync(PhonebookRecordSaveRequest saveRequest)
        {
            var businessModel = businessModelGenerator.Generate(saveRequest);

            var id = await dao.SaveAsync(businessModel).ConfigureAwait(false);
            return id;
        }

        public Task<PhonebookRecord> GetAsync(int id)
        {
            return dao.GetAsync(id);
        }
    }
}
