using TelegramCalculator.DataProviders;

namespace TelegramCalculator.Configurations
{
    internal static class Configurations
    {
        private static ITelegramConfigurationsProvider telegramConfigurationsProvider;

        public static void SetConfigurationProvider(ITelegramConfigurationsProvider provider)
        {
            telegramConfigurationsProvider = provider;
        }

        public static string Get(string what) => what switch
        {
            "api_id" => "15434226",
            "api_hash" => "5e4d89930f29e6b0eed73abf08fce0e2",
            "phone_number" => telegramConfigurationsProvider.GetPhoneNumber(),
            "verification_code" => telegramConfigurationsProvider.GetVerificationCode(),
            _ => null,
        };
    }
}
