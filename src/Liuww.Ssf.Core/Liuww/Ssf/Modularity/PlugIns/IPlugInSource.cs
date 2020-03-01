using System;

namespace Liuww.Ssf.Modularity.PlugIns
{
    public interface IPlugInSource
    {
        Type[] GetModules();
    }
}