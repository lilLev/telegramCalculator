using System;

namespace TelegramCalculator.UI.Events
{
    public class TelegramEventArgs<T> : EventArgs
    {
        public TelegramEventArgs(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
    }

}
