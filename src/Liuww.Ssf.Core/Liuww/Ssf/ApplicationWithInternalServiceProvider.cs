using System;
using Microsoft.Extensions.DependencyInjection;

namespace Liuww.Ssf
{
    public class ApplicationWithInternalServiceProvider:ApplicationBase,
        IApplicationWithInternalServiceProvider
    {
        public IServiceScope ServiceScope { get; private set; }
        public ApplicationWithInternalServiceProvider(Type startupModuleType, Action<ApplicationCreationOptions> optionsAction
        ) : this(
            startupModuleType,
            new ServiceCollection(),
            optionsAction)
        {

        }
        private ApplicationWithInternalServiceProvider(Type startupModuleType,IServiceCollection services,Action<ApplicationCreationOptions> optionsAction
        ) : base(
            startupModuleType,
            services,
            optionsAction)
        {
            Services.AddSingleton<IApplicationWithInternalServiceProvider>(this);
        }
        public void Initialize()
        {
            ServiceScope = Services.BuildServiceProviderFromFactory().CreateScope();
            SetServiceProvider(ServiceScope.ServiceProvider);

            InitializeModules();
        }

        public override void Dispose()
        {
            base.Dispose();
            ServiceScope.Dispose();
        }

    }
}