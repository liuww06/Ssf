using System;
using Liuww.Ssf;
using Liuww.Ssf.Modularity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionApplicationExtensions
    {
        public static IApplicationWithExternalServiceProvider AddApplication<TStartupModule>(this IServiceCollection services,
            Action<ApplicationCreationOptions> optionsAction = null)
            where TStartupModule : IModule
        {
            return ApplicationFactory.Create<TStartupModule>(services, optionsAction);
        }

        public static IApplicationWithExternalServiceProvider AddApplication(this IServiceCollection services, Type startupModuleType,Action<ApplicationCreationOptions> optionsAction = null)
        {
            return ApplicationFactory.Create(startupModuleType, services, optionsAction);
        }
    }
}