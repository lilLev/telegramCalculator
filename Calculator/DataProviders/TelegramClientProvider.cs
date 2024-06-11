using TelegramCalculator.Services;
using System;
using System.Threading.Tasks;
using WTelegram;

namespace TelegramCalculator.DataProviders
{
    internal class TelegramClientProvider : ITelegramClientProvider
    {
        private readonly ILogger _logger;

        public TelegramClientProvider(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Client> Get(Func<string, string> config)
        {
            try
            {
                var client = new Client(config);
                
                var my = await client.LoginUserIfNeeded();
                return client;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
