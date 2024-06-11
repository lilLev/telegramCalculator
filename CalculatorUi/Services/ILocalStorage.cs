namespace TelegramCalculator.UI.Services
{
    internal interface ILocalStorage
    {
        LocalAuthData Get();
        void Set(LocalAuthData value);
    }
}