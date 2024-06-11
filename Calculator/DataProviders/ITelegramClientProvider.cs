using System;
using System.Threading.Tasks;
using WTelegram;

namespace TelegramCalculator.DataProviders
{
    internal interface ITelegramClientProvider
    {
        Task<Client> Get(Func<string, string> config);
    }
}