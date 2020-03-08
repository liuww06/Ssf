using Liuww.Ssf.Modularity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using Liuww.Ssf.DependencyInjection;
using Liuww.Ssf.Internal;

namespace Liuww.Ssf
{
    public abstract class ApplicationBase : IApplication
    {
        public Type StartupModuleType { get; }

        public IServiceCollection Services { get; }
        public IServiceProvider ServiceProvider { get; private set; }

        public IReadOnlyList<IModuleDescriptor> Modules { get; }
        internal ApplicationBase(
            Type startupModuleType,
            IServiceCollection services,
            Action<ApplicationCreationOptions> optionsAction)
        {

            StartupModuleType = startupModuleType;
            Services = services;

            services.TryAddObjectAccessor<IServiceProvider>();

            var options = new ApplicationCreationOptions(services);
            optionsAction?.Invoke(options);

            services.AddSingleton<IApplication>(this);
            services.AddSingleton<IModuleContainer>(this);

            services.AddCoreServices();
            services.AddCoreAbpServices(this, options);

            Modules = LoadModules(services, options);
        }

        public virtual void Dispose()
        {
            //ToDO: 
        }

        public void Shutdown()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .ShutdownModules(new ApplicationShutdownContext(scope.ServiceProvider));
            }
        }

        protected virtual void SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            ServiceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>().Value = ServiceProvider;
        }
        protected virtual void InitializeModules()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .InitializeModules(new ApplicationInitializationContext(scope.ServiceProvider));
            }
        }

        private IReadOnlyList<IModuleDescriptor> LoadModules(IServiceCollection services, ApplicationCreationOptions options)
        {
            return services
                .GetSingletonInstance<IModuleLoader>()
                .LoadModules(
                    services,
                    StartupModuleType,
                    options.PlugInSources
                );
        }
    }
}