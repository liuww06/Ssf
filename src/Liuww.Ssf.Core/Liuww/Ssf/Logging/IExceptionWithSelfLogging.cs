using Microsoft.Extensions.Logging;

namespace Liuww.Ssf.Logging
{
    public interface IExceptionWithSelfLogging
    {
        void Log(ILogger logger);
    }
}