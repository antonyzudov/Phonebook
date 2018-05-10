using PhonebookApp.Models;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IPhonebookRecordDao
    {
        Task<int> SaveAsync(PhonebookRecord model);

        Task<PhonebookRecord> GetAsync(int id);
    }
}
