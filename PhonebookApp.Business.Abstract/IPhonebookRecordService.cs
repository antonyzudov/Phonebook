using PhonebookApp.Business.Abstract.Models;
using PhonebookApp.Models;
using System.Threading.Tasks;

namespace PhonebookApp.Business.Abstract
{
    public interface IPhonebookRecordService
    {
        Task<int> SaveAsync(PhonebookRecordSaveRequest saveRequest);

        Task<PhonebookRecord> GetAsync(int id);
    }
}
