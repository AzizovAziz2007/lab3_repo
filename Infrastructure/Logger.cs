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
                    // РЕФАКТОРИНГ: Выделение метода
                    string logEntry = FormatLogEntry(level, message);
                    WriteToFile(logEntry);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to write to log: {ex.Message}");
                }
            }
        }

        // Выделенный метод 1: Форматирование строки
        private string FormatLogEntry(string level, string message)
        {
            return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
        }

        // Выделенный метод 2: Запись в файл
        private void WriteToFile(string entry)
        {
            File.AppendAllText(_logFilePath, entry + Environment.NewLine);
        }
    }
}
