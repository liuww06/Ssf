using System;

namespace Liuww.Ssf.Modularity
{
    public interface IDependedTypesProvider
    {
        Type[] GetDependedTypes();
    }
}