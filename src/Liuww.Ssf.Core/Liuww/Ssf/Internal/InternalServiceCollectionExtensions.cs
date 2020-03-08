using Liuww.Ssf.Modularity;
using Liuww.Ssf.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Liuww.Ssf.Internal
{
    public static class InternalServiceCollectionExtensions
    {
        internal static void AddCoreServices(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddLogging();
            services.AddLocalization();
        }
        internal static void AddCoreAbpServices(this IServiceCollection services,
            IApplication application,
            ApplicationCreationOptions applicationCreationOptions)
        {
            var moduleLoader = new ModuleLoader();
            var assemblyFinder = new AssemblyFinder(application);
            var typeFinder = new TypeFinder(assemblyFinder);

            if (!services.IsAdded<IConfiguration>())
            {
                services.ReplaceConfiguration(
                    ConfigurationHelper.BuildConfiguration(
                        applicationCreationOptions.Configuration
                    )
                );
            }

            services.TryAddSingleton<IModuleLoader>(moduleLoader);
            services.TryAddSingleton<IAssemblyFinder>(assemblyFinder);
            services.TryAddSingleton<ITypeFinder>(typeFinder);

            services.AddAssemblyOf<IApplication>();

            services.Configure<ModuleLifecycleOptions>(options =>
            {
                options.Contributors.Add<OnPreApplicationInitializationModuleLifecycleContributor>();
                options.Contributors.Add<OnApplicationInitializationModuleLifecycleContributor>();
                options.Contributors.Add<OnPostApplicationInitializationModuleLifecycleContributor>();
                options.Contributors.Add<OnApplicationShutdownModuleLifecycleContributor>();
            });
        }
    }
}