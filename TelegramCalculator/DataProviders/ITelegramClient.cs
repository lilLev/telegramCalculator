using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramCalculator.Service.Models;
using TL;

namespace TelegramCalculator.DataProviders
{
    public interface ITelegramClient : IDisposable
    {
        long UserId { get; }
        Task LoginAsync();
        Task LogoutAsync();
        Task<List<ChatShort>> GetDialogShortsAsync();
        Task<List<ChatShort>> GetChatShortsAsync();
        Task SendMessageAsync(InputPeer peer, string message);
        Task DeleteMessagesAsync(int[] ids, bool forAll = false);
        Task<Messages_MessagesBase> GetMessageHistoryAsync(InputPeer peer, int offsetId = 0,
            DateTime dateTimeOffset = default, int addOffset = 0);
    }
}