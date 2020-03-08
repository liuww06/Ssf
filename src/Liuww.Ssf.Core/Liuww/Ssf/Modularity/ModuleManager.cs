using System;
using System.Collections.Generic;
using System.Linq;
using Liuww.Ssf.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Liuww.Ssf.Modularity
{
    public class ModuleManager : IModuleManager, ISingletonDependency
    {
        private readonly IModuleContainer _moduleContainer;
        private readonly IEnumerable<IModuleLifecycleContributor> _lifecycleContributors;
        private readonly ILogger<ModuleManager> _logger;

        public ModuleManager(IModuleContainer moduleContainer,
            ILogger<ModuleManager> logger,
            IOptions<ModuleLifecycleOptions> options,
            IServiceProvider serviceProvider)
        {
            _moduleContainer = moduleContainer;
            _logger = logger;
            _lifecycleContributors = options.Value.Contributors.Select(serviceProvider.GetRequiredService)
                .Cast<IModuleLifecycleContributor>()
                .ToArray();
        }
        public void InitializeModules(ApplicationInitializationContext context)
        {
            LogListOfModules();
            foreach (var lifecycleContributor in _lifecycleContributors)
            {
                foreach (var module in _moduleContainer.Modules)
                {
                    lifecycleContributor.Initialize(context,module.Instance);
                }
            }
            _logger.LogInformation("Initialized all Ssf modules.");
        }
        private void LogListOfModules()
        {
            _logger.LogInformation("Loaded Ssf modules:");

            foreach (var module in _moduleContainer.Modules)
            {
                _logger.LogInformation("- " + module.Type.FullName);
            }
        }

        public void ShutdownModules(ApplicationShutdownContext context)
        {
            var modules = _moduleContainer.Modules.Reverse().ToList();
            foreach (var lifecycleContributor in _lifecycleContributors)
            {
                foreach (var module in modules)
                {
                    lifecycleContributor.Shutdown(context, module.Instance);
                }
            }
        }
    }
}