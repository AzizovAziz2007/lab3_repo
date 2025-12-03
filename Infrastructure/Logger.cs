using System;
using System.IO;

namespace HotelManagementSystem.Infrastructure
{
    /// <summary>
    /// Простой логгер для записи событий системы
    /// </summary>
    public class Logger
    {
        private readonly string _logFilePath;
        private readonly object _lockObject = new object();

        public Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void LogInfo(string message)
        {
            WriteLog("INFO", message);
        }

        public void LogError(string message, Exception ex = null)
        {
            var fullMessage = ex != null ? $"{message}: {ex.Message}\n{ex.StackTrace}" : message;
            WriteLog("ERROR", fullMessage);
        }

        public void LogWarning(string message)
        {
            WriteLog("WARNING", message);
        }

        public void LogDebug(string message)
        {
            WriteLog("DEBUG", message);
        }

        private void WriteLog(string level, string message)
        {
            lock (_lockObject)
            {
                try
                {
                    var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
                    File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    // Если не удается записать в лог, выводим в консоль
                    Console.WriteLine($"Failed to write to log: {ex.Message}");
                }
            }
        }
    }
}
