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
                await sr.WriteAsync($"MESSAGE {DateTime.Now}: {message}");
            }
        }

        public async Task LogException(Exception ex)
        {
            using (var sr = new StreamWriter(filePath, true))
            {
                await sr.WriteLineAsync("--------------------------------------");
                await sr.WriteLineAsync($"START {DateTime.Now}");
                await sr.WriteLineAsync("EXCEPTION");
                await sr.WriteLineAsync($"{ex}");
                await sr.WriteLineAsync($"END {DateTime.Now}");
                await sr.WriteLineAsync("--------------------------------------");
            }
        }
    }
}
