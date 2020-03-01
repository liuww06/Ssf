using System;
using System.Collections.Generic;
using System.Reflection;

namespace Liuww.Ssf.Modularity
{
    public interface IModuleDescriptor
    {
        Type Type { get; }
        Assembly Assembly { get; }
        IModule Instance { get; }
        bool IsLoadedAsPlugIn { get; }
        IReadOnlyList<IModuleDescriptor> Dependencies { get; }

    }
}