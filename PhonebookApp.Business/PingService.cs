using Domain.Abstract;
using PhonebookApp.Business.Abstract;
using System.Threading.Tasks;

namespace PhonebookApp.Business
{
    public class PingService : IPingService
    {
        private readonly IPingDao dao;

        public PingService(IPingDao dao)
        {
            this.dao = dao;
        }

        public Task<string> PingAsync()
        {
            return dao.PingAsync();
        }
    }
}
