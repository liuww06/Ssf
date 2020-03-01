using System;

namespace Liuww.Ssf
{
    public interface IAbpApplicationWithExternalServiceProvider:IApplication
    {
        void Initialize(IServiceProvider serviceProvider);
    }
}