using Microsoft.Extensions.DependencyInjection;
using TelegramCalculator.Processors;
using TelegramCalculator.Services;
using TelegramCalculator.UI.Services;

namespace TelegramCalculator.UI.Configurations
{
    internal static class DiConfig
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services) =>
            services.AddTelegramCalculator()
                    .AddScoped<Form1>()
                    .AddScoped<TelegramConfiguration>()
                    .AddScoped<ITelegramSumProcessor, TelegramSumProcessor>()
                    .AddScoped<ILocalStorage, LocalStorage>()
                    .AddSingleton<ILogger>(config => new FileLogger("dump.txt"));
    }
}
