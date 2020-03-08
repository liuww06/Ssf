using Liuww.Ssf.Modularity.PlugIns;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Liuww.Ssf
{
    public class ApplicationCreationOptions
    {
        public IServiceCollection Services { get;  }
        public PlugInSourceList PlugInSources { get; }
        public SsfConfigurationBuilderOptions Configuration { get; }
        public ApplicationCreationOptions(IServiceCollection services)
        {
            Services = services;
            PlugInSources = new PlugInSourceList();
            Configuration = new SsfConfigurationBuilderOptions();
        }
    }
}