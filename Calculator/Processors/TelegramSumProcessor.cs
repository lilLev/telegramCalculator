using TelegramCalculator.DataProviders;
using TelegramCalculator.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using TL;

namespace TelegramCalculator.Processors
{
    internal class TelegramSumProcessor
    {
        private readonly TelegramClientProvider _clientProvider;
        private readonly ILogger _logger;

        public TelegramSumProcessor(TelegramClientProvider clientProvider, ILogger logger)
        {
            _clientProvider = clientProvider ?? throw new ArgumentNullException(nameof(clientProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Process(string chatName)
        {
            using var client = await _clientProvider.Get(Configurations.Configurations.Get);

            try
            {
                var chatsResponse = await client.Messages_GetAllChats();
                var targetChat = chatsResponse.chats.FirstOrDefault(c => c.Value.Title.Equals(chatName));
                
                if (targetChat.Value == null)
                {
                    _logger.LogError("Chat with name {0} was not found", chatName);
                    return;
                }
                var targetChatInputPeer = targetChat.Value.ToInputPeer();
                var messagesResponse = await client.Messages_GetHistory(targetChatInputPeer);

                var messages = messagesResponse.Messages
                    .Select(m => m is Message _m && double.TryParse(_m.message, out var p) ? new { UserId = _m.from_id.ID, Content = p, MessageId = _m.ID } : null)
                    .Where(m => m != null);

                double result = 0;
                foreach (var message in messages)
                {
                    if (message.UserId == client.UserId)
                    {
                        _logger.LogInformation("{0} from {0} (self)", message.Content, message.UserId);

                        result += message.Content;
                    }
                    else
                    {
                        _logger.LogInformation("{0} from {0}", message.Content, message.UserId);

                        result -= message.Content;
                    }
                }

                await client.Messages_DeleteMessages(messages.Select(m => m.MessageId).ToArray(), true);
                await client.SendMessageAsync(targetChatInputPeer, result.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
           
            _logger.LogInformation("Done.");
        }
    }
}
