using System;
using TelegramCalculator.DataProviders;
using TelegramCalculator.UI.Events;
using TelegramCalculator.UI.Services;

namespace TelegramCalculator.UI.Configurations
{
    internal class TelegramConfiguration : ITelegramConfigurationsProvider
    {
        private readonly ILocalStorage _localStorage;

        public event EventHandler<TelegramEventArgs<string>> VerificationCodeEventHandler;

        public TelegramConfiguration(ILocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public string GetPhoneNumber()
        {
            return _localStorage.Get().PhoneNumber;
        }

        public string GetVerificationCode()
        {
            var args = new TelegramEventArgs<string>(null);
            VerificationCodeEventHandler(this, args);
            return args.Value;
        }
    }
}
