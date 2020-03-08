using System;

namespace Liuww.Ssf
{
    public interface IApplicationWithExternalServiceProvider:IApplication
    {
        void Initialize(IServiceProvider serviceProvider);
    }
}