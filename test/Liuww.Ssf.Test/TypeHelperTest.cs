using System;
using System.Reflection.Metadata.Ecma335;
using Xunit;
using Liuww.Ssf.Reflection;

namespace Liuww.Ssf.Test
{ 
    public class TypeHelperTest
    {
        [Fact]
        public void IsFunc_Test()
        {
            Func<bool> obj = () => true;
            Assert.True(TypeHelper.IsFunc(obj));
        }
        [Fact]
        public void IsPrimitiveExtendedInternal_Test()
        {
            Assert.True(TypeHelper.IsPrimitiveExtended(typeof(int)));
            Assert.True(TypeHelper.IsPrimitiveExtended(typeof(DateTime)));
            Assert.False(TypeHelper.IsPrimitiveExtended(typeof(Nullable)));
            Assert.False(TypeHelper.IsPrimitiveExtended(typeof(Nullable),true));
        }
    }
}