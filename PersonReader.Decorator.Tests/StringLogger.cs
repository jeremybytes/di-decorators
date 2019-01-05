using Logging;
using System;
using System.Threading.Tasks;

namespace PersonReader.Decorator.Tests
{
    public class StringLogger : ILogger
    {
        public string Log { get; set; }

        public StringLogger()
        {
            Log = string.Empty;
        }

        public async Task LogException(Exception ex)
        {
            await Task.Delay(1);
            Log += $"{ex}";
        }

        public async Task LogMessage(string message)
        {
            await Task.Delay(1);
            Log += $"{message}";
        }
    }
}
