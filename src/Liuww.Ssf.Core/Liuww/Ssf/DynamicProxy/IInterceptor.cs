using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Liuww.Ssf.DynamicProxy
{
    public interface IInterceptor
    {
        Task InterceptAsync(IMethodInvocation invocation);
    }
}
