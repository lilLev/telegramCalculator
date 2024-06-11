using System;

namespace TelegramCalculator.Service.Services
{
    class Progress : IProgress<int>
    {
        public int LoadedMessages { get; private set; }
        public void Report(int value)
        {
            LoadedMessages += value;
        }
    }
}
