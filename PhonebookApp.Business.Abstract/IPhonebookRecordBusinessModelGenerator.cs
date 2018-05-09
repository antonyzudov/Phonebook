using PhonebookApp.Business.Abstract.Models;
using PhonebookApp.Models;

namespace PhonebookApp.Business.Abstract
{
    public interface IPhonebookRecordBusinessModelGenerator
    {
        PhonebookRecord Generate(PhonebookRecordSaveRequest saveRequest);
    }
}
