using System;
using System.Collections.Generic;
using System.Text;
using Liuww.Ssf.DependencyInjection;

namespace Liuww.Ssf
{
    public class ApplicationInitializationContext:IServiceProviderAccessor
    {
        public IServiceProvider ServiceProvider { get; set; }

        public ApplicationInitializationContext(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

    }
}
