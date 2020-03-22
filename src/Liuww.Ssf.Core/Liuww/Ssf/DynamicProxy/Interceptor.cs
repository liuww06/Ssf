using System.Threading.Tasks;

namespace Liuww.Ssf.DynamicProxy
{
    public abstract class Interceptor : IInterceptor
    {
        public abstract Task InterceptAsync(IMethodInvocation invocation);
    }
}