using TelegramCalculator.DataProviders;
using TelegramCalculator.Processors;
using TelegramCalculator.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace TelegramCalculator
{   
    public class Program
    {
        public async static Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<TelegramClientProvider>()
                .AddScoped<ILogger, ConsoleLogger>()
                .AddScoped<TelegramSumProcessor>()
                .BuildServiceProvider();

            var processor = serviceProvider.GetRequiredService<TelegramSumProcessor>();

            await processor.Process("");
        }
    }
}
