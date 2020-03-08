using System.Collections.Generic;
using System.Reflection;

namespace Liuww.Ssf.Reflection
{
    public interface IAssemblyFinder
    {
        IReadOnlyList<Assembly> Assemblies { get; }
    }
}