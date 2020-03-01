using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Liuww.Ssf.Modularity
{
    public class ServiceConfigurationContext
    {
        public IServiceCollection Services { get; }
        public IDictionary<string, object> Items { get; }
        public object this[string key]
        {
            get => Items.GetOrDefault(key);
            set => Items[key] = value;
        }
        public ServiceConfigurationContext( IServiceCollection services)
        {
            Services = services;
            Items = new Dictionary<string, object>();
        }
    }
}