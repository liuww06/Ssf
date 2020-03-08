﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace Liuww.Ssf.Modularity
{
    public class ModuleDescriptor: IModuleDescriptor
    {
        public Type Type { get; }

        public Assembly Assembly { get; }

        public IModule Instance { get; }

        public bool IsLoadedAsPlugIn { get; }
        public IReadOnlyList<IModuleDescriptor> Dependencies => _dependencies.ToImmutableList();
        private readonly List<IModuleDescriptor> _dependencies;

        public ModuleDescriptor(Type type, IModule instance,
            bool isLoadedAsPlugIn)
        {

            if (!type.GetTypeInfo().IsAssignableFrom(instance.GetType()))
            {
                throw new ArgumentException(
                    $"Given module instance ({instance.GetType().AssemblyQualifiedName}) is not an instance of given module type: {type.AssemblyQualifiedName}");
            }

            Type = type;
            Assembly = type.Assembly;
            Instance = instance;
            IsLoadedAsPlugIn = isLoadedAsPlugIn;

            _dependencies = new List<IModuleDescriptor>();
        }
        public void AddDependency(IModuleDescriptor descriptor)
        {
            _dependencies.AddIfNotContains(descriptor);
        }
        public override string ToString()
        {
            return $"[ModuleDescriptor {Type.FullName}]";
        }
    }
}