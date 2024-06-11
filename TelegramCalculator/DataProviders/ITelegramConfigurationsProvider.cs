namespace TelegramCalculator.DataProviders
{
    public interface ITelegramConfigurationsProvider
    {
        string GetPhoneNumber();
        string GetVerificationCode();
    }
}
