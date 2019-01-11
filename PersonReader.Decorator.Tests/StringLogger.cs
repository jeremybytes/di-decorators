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

        public Task LogException(Exception ex)
        {
            Log += $"{ex}";
            return Task.CompletedTask;
        }

        public Task LogMessage(string message)
        {
            Log += $"{message}";
            return Task.CompletedTask;
        }
    }
}
