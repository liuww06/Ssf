namespace Liuww.Ssf.Modularity
{
    public interface IModuleManager
    {
        void InitializeModules(ApplicationInitializationContext context);

        void ShutdownModules(ApplicationShutdownContext context);
    }
}