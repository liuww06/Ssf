using System;
using System.Runtime.Serialization;

namespace Liuww.Ssf
{
    public class SsfException:Exception
    {
        public SsfException()
        {
                
        }

        public SsfException(string message):base(message)
        {
            
        }

        public SsfException(string message,Exception innerException)
        :base(message,innerException)
        {
                
        }
        public SsfException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}