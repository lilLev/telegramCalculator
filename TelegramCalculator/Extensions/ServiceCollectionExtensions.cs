using Microsoft.Extensions.DependencyInjection;
using TelegramCalculator.DataProviders;
using TelegramCalculator.Processors;
using TelegramCalculator.Services;

namespace TelegramCalculator
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramCalculator(this IServiceCollection services) =>
            services.AddScoped<ILogger, FileLogger>()
                    .AddScoped<ITelegramSumProcessor, TelegramSumProcessor>()
                    .AddScoped<ITelegramClient, TelegramClient>(config =>
                        new TelegramClient(Configurations.Configurations.Get)
                    );
    }
}
