namespace TelegramCalculator.Services
{
    public interface ILogger
    {
        void LogError(string message);
        void LogError(string message, params object[] args);
        void LogInformation(string message);
        void LogInformation(string message, params object[] args);
        void LogWarning(string message);
        void LogWarning(string message, params object[] args);
    }
}