using TelegramCalculator.DataProviders;
using TelegramCalculator.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using TL;
using System.Collections.Generic;
using TelegramCalculator.Service.Models;

namespace TelegramCalculator.Processors
{
    public class TelegramSumProcessor : ITelegramSumProcessor, IDisposable
    {
        private readonly ITelegramClient _client;

        private readonly ILogger _logger;

        private bool _disposed;

        public TelegramSumProcessor(ITelegramClient clientProvider, ILogger logger)
        {
            _client = clientProvider ?? throw new ArgumentNullException(nameof(clientProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void SetConfig(ITelegramConfigurationsProvider telegramConfigurationsProvider)
        {
            Configurations.Configurations.SetConfigurationProvider(telegramConfigurationsProvider);
        }

        public async Task Logout()
        {
            await _client.LogoutAsync();
        }

        public async Task Login()
        {
            await _client.LoginAsync();
        }

        public async Task<List<ChatShort>> GetChats()
        {
            return await _client.GetChatShortsAsync();
        }

        public async Task<List<ChatShort>> GetDialogs()
        {
            return await _client.GetDialogShortsAsync();
        }

        public async Task Process(InputPeer peer, IProgress<int> progress, int offsetId = 0, DateTime dateTimeOffset = default, int addOffset = 0, bool deleteAfter = true, bool sendMessage = true)
        {
            if (_client == null)
            {
                throw new ArgumentException(nameof(_client));
            }
            try
            {
                var messagesResponseArray = new List<Messages_MessagesBase>();
                var offset = 0;
                while (true)
                {
                    messagesResponseArray.Add(await _client.GetMessageHistoryAsync(peer, addOffset: offset));
                    offset += 100;
                    progress.Report(offset);
                    if (!messagesResponseArray.Last().Messages.Any() || messagesResponseArray.Last().Messages.Any(m => m.Date.CompareTo(dateTimeOffset) <= 0))
                    {
                        break;
                    }
                    await Task.Delay(5000);
                }

                //var messagesResponse = await _client.GetMessageHistoryAsync(peer, addOffset: 1);
                var messagesResponse = new List<MessageBase>();
                messagesResponse = messagesResponseArray.SelectMany(m => m.Messages).ToList();
                var messagesToProcess = messagesResponse?.Where(m => m is Message _m && _m.message.Length < 10 && m.ReplyTo == null && m.Date.CompareTo(dateTimeOffset) > 0).Select(m => m as Message);
                if (messagesToProcess == null || !messagesToProcess.Any())
                {
                    _logger.LogError("Chat was not found or empty.");
                    throw new Exception("Chat was not found or empty.");
                }

                var joinedMessages = string.Join('\n', messagesToProcess.Select(m => m.message).ToArray());
                _logger.LogInformation("Messages found:\n{0}", joinedMessages);

                var messages = messagesToProcess
                    .Select(m => double.TryParse(m.message.Replace(',', '.'), out var p) ? new MessageShort(m.ID, m.from_id?.ID, p) : null)
                    .Where(m => m != null);

                var sum = GetSum(messages.ToArray());

                _logger.LogInformation("Sum: {0}", sum);

                if (deleteAfter)
                {
                    await _client.DeleteMessagesAsync(messages.Select(m => m.Id).ToArray(), true);
                }
                if (sendMessage)
                {
                    await _client.SendMessageAsync(peer, sum.ToString("0.00"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

            _logger.LogInformation("Done.");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _client.Dispose();
            }
            _disposed = true;
        }

        private double GetSum(MessageShort[] messages)
        {
            double sum = 0;
            foreach (var message in messages)
            {
                if (message.UserId == _client.UserId)
                {
                    _logger.LogInformation("{0} from {1} (self)", message.Content, message.UserId);

                    sum += message.Content;
                }
                else
                {
                    _logger.LogInformation("{0} from {1}", message.Content, message.UserId);

                    sum -= message.Content;
                }
            }
            return sum;
        }
    }
}
