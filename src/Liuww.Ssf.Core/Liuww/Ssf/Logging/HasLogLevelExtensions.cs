using Microsoft.Extensions.Logging;

namespace Liuww.Ssf.Logging
{
    public static class HasLogLevelExtensions
    {
        public static TException WithLogLevel<TException>(this TException exception, LogLevel logLevel)
            where TException : IHasLogLevel
        {
            exception.LogLevel = logLevel;

            return exception;
        }
    }
}