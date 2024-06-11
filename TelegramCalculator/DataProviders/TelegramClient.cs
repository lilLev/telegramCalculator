using System;
using System.Threading.Tasks;
using WTelegram;
using TL;
using System.Linq;
using TelegramCalculator.Service.Models;
using System.Collections.Generic;

namespace TelegramCalculator.DataProviders
{
    public class TelegramClient : ITelegramClient
    {
        private readonly Client _client;

        private bool _disposed;

        public long UserId { get => _client.UserId; }

        public TelegramClient(Func<string, string> configProvider)
        {
            _client = new Client(configProvider);
        }

        public async Task LoginAsync()
        {
            await _client.LoginUserIfNeeded();
        }

        public async Task LogoutAsync()
        {
            GuardFromUnauthorized();

            await _client.Auth_LogOut();
        }

        public async Task<List<ChatShort>> GetDialogShortsAsync()
        {
            GuardFromUnauthorized();

            var response = await _client.Messages_GetDialogs() as Messages_DialogsSlice;
            return response.users
                .Select(c => new ChatShort(
                    c.Value.ToInputPeer(),
                    $"{c.Value.first_name} {c.Value.last_name} @{c.Value.username}"))
                .ToList();
        }

        public async Task<List<ChatShort>> GetChatShortsAsync()
        {
            GuardFromUnauthorized();

            var response = await _client.Messages_GetAllChats();
            return response.chats
                .Select(c => new ChatShort(c.Value.ToInputPeer(), c.Value.Title))
                .ToList();
        }

        public async Task SendMessageAsync(InputPeer peer, string message)
        {
            await _client.SendMessageAsync(peer, message);
        }

        public async Task DeleteMessagesAsync(int[] ids, bool forAll = false)
        {
            await _client.Messages_DeleteMessages(ids, forAll);
        }

        public Task<Messages_MessagesBase> GetMessageHistoryAsync(InputPeer peer, int offsetId = 0,
            DateTime dateTimeOffset = default, int addOffset = 0)
        {
            GuardFromUnauthorized();

            return _client.Messages_GetHistory(peer, offsetId, dateTimeOffset, addOffset);
        }

        private void GuardFromUnauthorized()
        {
            if (_client?.UserId == 0)
            {
                throw new ArgumentException("Unauthorized.");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposible)
        {
            if (!_disposed)
            {
                return;
            }
            if (disposible)
            {
                _client.Dispose();
            }
            _disposed = true;
        }
    }
}
