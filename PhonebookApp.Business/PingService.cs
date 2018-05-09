using PhonebookApp.Business.Abstract;

namespace PhonebookApp.Business
{
    public class PingService : IPingService
    {
        public string Ping()
        {
            return "pong";
        }
    }
}
