using System;
using System.Collections.Generic;

namespace Liuww.Ssf.Reflection
{
    public interface ITypeFinder
    {
        IReadOnlyList<Type> Types { get; }
    }
}