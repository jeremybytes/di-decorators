using System;
using System.IO;
using System.Threading.Tasks;

namespace Logging
{
    public class FileLogger : ILogger
    {
        string filePath = AppDomain.CurrentDomain.BaseDirectory + "ExceptionLog.txt";

        public async Task LogMessage(string message)
        {
            using (var sr = new StreamWriter(filePath, true))
            {
                await sr.WriteLineAsync($"MESSAGE {DateTime.Now}: {message}");
            }
        }

        public async Task LogException(Exception ex)
        {
            using (var sr = new StreamWriter(filePath, true))
            {
                string message = "--------------------------------------";
                message += Environment.NewLine;
                message += $"START {DateTime.Now}{Environment.NewLine}";
                message += $"EXCEPTION{Environment.NewLine}";
                message += $"{ex}{Environment.NewLine}";
                message += $"END {DateTime.Now}{Environment.NewLine}";
                message += "--------------------------------------";

                await sr.WriteLineAsync(message);
            }
        }
    }
}
