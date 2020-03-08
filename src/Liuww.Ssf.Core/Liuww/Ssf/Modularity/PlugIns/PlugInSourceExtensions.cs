using System;
using System.Linq;

namespace Liuww.Ssf.Modularity.PlugIns
{
    public static class PlugInSourceExtensions
    {
        public static Type[] GetModulesWithAllDependencies(this IPlugInSource plugInSource)
        {

            return plugInSource
                .GetModules()
                .SelectMany(ModuleHelper.FindAllModuleTypes)
                .Distinct()
                .ToArray();
        }
    }
}