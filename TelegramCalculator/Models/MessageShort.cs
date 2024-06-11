namespace TelegramCalculator.Service.Models
{
    internal class MessageShort
    {
        public MessageShort(int id, long? userId, double content)
        {
            Id = id;
            UserId = userId;
            Content = content;
        }

        public int Id { get; set; }

        public long? UserId { get; set; }

        public double Content { get; set; }
    }
}
