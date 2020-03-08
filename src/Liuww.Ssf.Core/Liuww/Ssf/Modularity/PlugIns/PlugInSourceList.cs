using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Liuww.Ssf.Modularity.PlugIns
{
    public class PlugInSourceList:List<IPlugInSource>
    {
        internal Type[] GetAllModules()
        {
            return this.SelectMany(pluginSource => pluginSource.GetModulesWithAllDependencies())
                .Distinct()
                .ToArray();
        }
    }
}