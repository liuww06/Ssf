using System;
using System.Collections.Generic;

namespace Liuww.Ssf.Modularity
{
    public static class ModuleHelper
    {
        public static List<Type> FindAllModuleTypes(Type startupModuleType)
        {
            var moduleTypes = new List<Type>();

        }
        private static void AddModuleAndDependenciesResursively(List<Type> moduleTypes, Type moduleType)
        {
            Module.CheckAbpModuleType(moduleType);

            if (moduleTypes.Contains(moduleType))
            {
                return;
            }

            moduleTypes.Add(moduleType);

            foreach (var dependedModuleType in FindDependedModuleTypes(moduleType))
            {
                AddModuleAndDependenciesResursively(moduleTypes, dependedModuleType);
            }
        }
    }
}