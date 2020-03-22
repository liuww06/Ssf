using Microsoft.Extensions.DependencyInjection;

namespace Liuww.Ssf.DependencyInjection
{
    [ExposeServices(
        typeof(IHybridServiceScopeFactory),
        typeof(DefaultServiceScopeFactory)
        )]
    public class DefaultServiceScopeFactory : IHybridServiceScopeFactory, ITransientDependency
    {
        protected IServiceScopeFactory Factory { get; }

        public DefaultServiceScopeFactory(IServiceScopeFactory factory)
        {
            Factory = factory;
        }
        public IServiceScope CreateScope()
        {
            return Factory.CreateScope();
        }
    }
}