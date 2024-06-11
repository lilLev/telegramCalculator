using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramCalculator.DataProviders;
using TelegramCalculator.Service.Models;
using TL;

namespace TelegramCalculator.Processors
{
    public interface ITelegramSumProcessor
    {
        void SetConfig(ITelegramConfigurationsProvider telegramConfigurationsProvider);
        Task Login();
        Task Logout();
        Task<List<ChatShort>> GetChats();
        Task<List<ChatShort>> GetDialogs();
        Task Process(InputPeer peer, IProgress<int> progress, int offsetId = 0, DateTime dateTimeOffset = default, int addOffset = 0, bool deleteAfter = true, bool sendMessage = true);
    }
}