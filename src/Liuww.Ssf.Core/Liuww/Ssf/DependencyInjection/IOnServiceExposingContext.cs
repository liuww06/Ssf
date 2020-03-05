using System;
using System.Collections.Generic;

namespace Liuww.Ssf.DependencyInjection
{
    public interface IOnServiceExposingContext
    {
        Type ImplementationType { get; }

        List<Type> ExposedTypes { get; }
    }
}
