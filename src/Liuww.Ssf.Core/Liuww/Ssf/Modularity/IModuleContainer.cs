using System.Collections.Generic;

namespace Liuww.Ssf.Modularity
{
    public interface IModuleContainer
    {
        IReadOnlyList<IModuleDescriptor> Modules { get; }
    }
}