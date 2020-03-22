using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using Liuww.Ssf.Logging;
using Microsoft.Extensions.Logging;

namespace System
{
    public static class ExceptionExtensions
    {
        public static void ReThrow(this Exception exception)
        {
            ExceptionDispatchInfo.Capture(exception).Throw();
        }
        public static LogLevel GetLogLevel(this Exception exception, LogLevel defaultLevel = LogLevel.Error)
        {
            return (exception as IHasLogLevel)?.LogLevel ?? defaultLevel;
        }
    }
}
