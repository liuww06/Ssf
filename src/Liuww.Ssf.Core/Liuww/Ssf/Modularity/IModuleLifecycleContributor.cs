using Liuww.Ssf.DependencyInjection;

namespace Liuww.Ssf.Modularity
{
    public interface IModuleLifecycleContributor : ITransientDependency
    {
        void Initialize(ApplicationInitializationContext context, IModule module);

        void Shutdown(ApplicationShutdownContext context,IModule module);
    }
}