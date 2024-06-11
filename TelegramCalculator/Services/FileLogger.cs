using System;
using System.IO;

namespace TelegramCalculator.Services
{
    public class FileLogger : ILogger
    {
        private readonly string _fileName;
        public FileLogger(string fileName = null)
        {
            _fileName = fileName ?? $"{DateTime.Now.ToString("_MMddyyyy_HHmmss")}.txt";
        }
        public void LogError(string message)
        {
            using var writer = new StreamWriter(_fileName, true);
            writer.WriteLine($"Error: {message}");
        }

        public void LogError(string message, params object[] args)
        {
            using var writer = new StreamWriter(_fileName, true);
            writer.WriteLine($"Error: {string.Format(message, args)}");
        }

        public void LogInformation(string message)
        {
            using var writer = new StreamWriter(_fileName, true);
            writer.WriteLine($"Info: {message}");
        }

        public void LogInformation(string message, params object[] args)
        {
            using var writer = new StreamWriter(_fileName, true);
            writer.WriteLine($"Info: {string.Format(message, args)}");
        }

        public void LogWarning(string message)
        {
            using var writer = new StreamWriter(_fileName, true);
            writer.WriteLine($"Warning: {message}");
        }

        public void LogWarning(string message, params object[] args)
        {
            using var writer = new StreamWriter(_fileName, true);
            writer.WriteLine($"Warning: {string.Format(message, args)}");
        }
    }
}
