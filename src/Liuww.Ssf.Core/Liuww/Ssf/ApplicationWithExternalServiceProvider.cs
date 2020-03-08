using System;
using Microsoft.Extensions.DependencyInjection;

namespace Liuww.Ssf
{
    public class ApplicationWithExternalServiceProvider:ApplicationBase,IApplicationWithExternalServiceProvider
    {
        public ApplicationWithExternalServiceProvider(Type startupModuleType, IServiceCollection services, Action<ApplicationCreationOptions> optionsAction):base(startupModuleType, services, optionsAction)
        {
            services.AddSingleton<IApplicationWithExternalServiceProvider>(this);
        }

        public void Initialize(IServiceProvider serviceProvider)
        {
            SetServiceProvider(serviceProvider);
            InitializeModules();
        }

        public override void Dispose()
        {
            base.Dispose();
            if (ServiceProvider is IDisposable disposableServiceProvider)
            {
                disposableServiceProvider.Dispose();
            }
        }
    }
}