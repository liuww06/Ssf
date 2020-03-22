using Microsoft.Extensions.Logging;

namespace Liuww.Ssf.Logging
{
    public interface IHasLogLevel
    {
        LogLevel LogLevel { get; set; }
    }
}