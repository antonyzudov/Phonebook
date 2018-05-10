using Domain.Abstract;
using System.Threading.Tasks;
using Dapper;

namespace PhonebookApp.Domain
{
    public class PingDao : BaseDao, IPingDao
    {
        public Task<string> PingAsync()
        {
            return WithConnection(c =>
            {
                return c.QueryFirstAsync<string>("select 'pong'");
            });
        }
    }
}
