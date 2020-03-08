using System;
using Liuww.Ssf.Modularity.PlugIns;
using Microsoft.Extensions.DependencyInjection;

namespace Liuww.Ssf.Modularity
{
    public interface IModuleLoader
    {
        IModuleDescriptor[] LoadModules(IServiceCollection services, Type startupModuleType,
            PlugInSourceList plugInSources
        );
    }
}