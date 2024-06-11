using TL;

namespace TelegramCalculator.Service.Models
{
    public class ChatShort
    {
        public ChatShort(InputPeer peer, string title)
        {
            Peer = peer;
            Title = title;
        }
        public InputPeer Peer { get; set; }

        public string Title { get; set; }
    }
}
