﻿using System.Threading.Tasks;

namespace PhonebookApp.Business.Abstract
{
    public interface IPingService
    {
        Task<string> PingAsync();
    }
}
