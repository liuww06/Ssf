using System;
using System.Collections.Generic;
using System.Text;

namespace Liuww.Ssf.DependencyInjection
{
    public class OnServiceExposingContext : IOnServiceExposingContext
    {
        public Type ImplementationType { get; }

        public List<Type> ExposedTypes { get; }

        public OnServiceExposingContext(Type implementationType, List<Type> exposedTypes)
        {
            ImplementationType = implementationType;
            ExposedTypes = exposedTypes;
        }
    }
}
