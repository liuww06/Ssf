using System;
using Liuww.Ssf.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Liuww.Ssf
{
    public static class ApplicationFactory
    {
        public static IApplicationWithInternalServiceProvider Create<TStartupModule>(
            Action<ApplicationCreationOptions> optionsAction = null) where TStartupModule:IModule
        {
            return Create(typeof(TStartupModule), optionsAction);
        }
        public static IApplicationWithInternalServiceProvider Create(
            Type startupModuleType,
            Action<ApplicationCreationOptions> optionsAction = null)
        {
            return new ApplicationWithInternalServiceProvider(startupModuleType, optionsAction);
        }
        public static IApplicationWithExternalServiceProvider Create<TStartupModule>(IServiceCollection services,Action<ApplicationCreationOptions> optionsAction = null)
            where TStartupModule : IModule
        {
            return Create(typeof(TStartupModule), services, optionsAction);
        }

        public static IApplicationWithExternalServiceProvider Create(Type startupModuleType,IServiceCollection services,Action<ApplicationCreationOptions> optionsAction = null)
        {
            return new ApplicationWithExternalServiceProvider(startupModuleType, services, optionsAction);
        }
    }
}