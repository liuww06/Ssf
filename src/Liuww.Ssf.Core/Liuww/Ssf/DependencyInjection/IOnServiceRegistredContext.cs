using Liuww.Ssf.Collections;
using Liuww.Ssf.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liuww.Ssf.DependencyInjection
{
    public interface IOnServiceRegistredContext
    {
        ITypeList<IInterceptor> Interceptors { get; }

        Type ImplementationType { get; }
    }
}
