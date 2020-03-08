using System;
using Liuww.Ssf.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Liuww.Ssf
{
    public interface IApplication:IModuleContainer,IDisposable
    {
        /// <summary>
        /// Type of startup(entrance) module of the application
        /// </summary>
        Type StartupModuleType { get; }
        /// <summary>
        /// List of services registered to this application.
        /// Can not add new services to this collection after application initialize.
        /// </summary>
        IServiceCollection Services { get; }
        /// <summary>
        /// Reference to the root service provider used by the application.
        /// This can not be used before initialize the application.
        /// </summary>
        IServiceProvider ServiceProvider { get; }
        /// <summary>
        /// used to gracefully shutdown the application and all modules.
        /// </summary>
        void Shutdown();
    }
}