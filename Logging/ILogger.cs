using System;
using System.Threading.Tasks;

namespace Logging
{
    public interface ILogger
    {
        Task LogException(Exception ex);
        Task LogMessage(string message);
    }
}