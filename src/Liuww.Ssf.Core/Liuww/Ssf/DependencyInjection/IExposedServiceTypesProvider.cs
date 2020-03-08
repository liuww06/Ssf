using System;

namespace Liuww.Ssf.DependencyInjection
{
    public interface IExposedServiceTypesProvider
    {
        Type[] GetExposedServiceTypes(Type targetType);
    }
}