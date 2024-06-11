using System;
using TL;

namespace TelegramCalculator.UI.ViewModels
{
    public class ChatQuery
    {
        public DateTime DateTimeOffset { get; set; }

        public InputPeer InputPeer { get; set; }

        public ChatQuery(InputPeer inputPeer, DateTime dateTimeOffset)
        {
            InputPeer = inputPeer;
            DateTimeOffset = dateTimeOffset;
        }
    }
}
