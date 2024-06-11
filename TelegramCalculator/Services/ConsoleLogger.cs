using System;
using System.Text;

namespace TelegramCalculator.Services
{
    internal class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            WriteLine(message, ConsoleColor.Red);
        }

        public void LogError(string message, params object[] args)
        {
            WriteLineWithArgs(message, ConsoleColor.Red, args);
        }

        public void LogInformation(string message)
        {
            WriteLine(message, ConsoleColor.White);
        }

        public void LogInformation(string message, params object[] args)
        {
            WriteLineWithArgs(message, ConsoleColor.White, args);
        }

        public void LogWarning(string message)
        {
            WriteLine(message, ConsoleColor.Yellow);
        }

        public void LogWarning(string message, params object[] args)
        {
            WriteLineWithArgs(message, ConsoleColor.Yellow, args);
        }

        private void Write(string message, ConsoleColor color)
        {
            var consoleForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.Write(message);

            Console.ForegroundColor = consoleForegroundColor;
        }

        private void WriteLine(string message, ConsoleColor color)
        {
            Write(message, color);
            Console.Write('\n');
        }

        private void WriteLineWithArgs(string message, ConsoleColor color, params object[] args)
        {
            var messageBulkWrite = new StringBuilder();
            for (int i = 0, i_ = 0; i < message?.Length; i++)
            {
                var character = message[i];
                if (character == '{')
                {
                    if (i_ == args.Length)
                    {
                        throw new Exception("Incorrect string format.");
                    }
                    while (message[++i] != '}')
                    {
                        if (i == message.Length)
                        {
                            throw new Exception("Incorrect string format.");
                        }
                    }
                    Write(messageBulkWrite.ToString(), color);
                    messageBulkWrite.Clear();
                    Write(args[i_++].ToString(), ConsoleColor.Blue);
                }
                else
                {
                    messageBulkWrite.Append(character);
                }
            }
            Write(messageBulkWrite.ToString(), color);
            Console.Write('\n');
        }
    }
}
