using System;

namespace Liuww.Ssf.Modularity
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute, IDependedTypesProvider
    {
        public Type[] DependedTypes { get; set; }
        public DependsOnAttribute(params Type[] dependedTypes)
        {
            DependedTypes = dependedTypes??new Type[0];
        }
        public virtual Type[] GetDependedTypes()
        {
            return DependedTypes ;
        }
    }
}
