using System;
using System.Collections.Generic;

namespace Liuww.Ssf.DependencyInjection
{
    public class ServiceExposingActionList : List<Action<IOnServiceExposingContext>>
    {
    }
}
