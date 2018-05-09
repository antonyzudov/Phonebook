using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IPingDao
    {
        Task<string> PingAsync();
    }
}
