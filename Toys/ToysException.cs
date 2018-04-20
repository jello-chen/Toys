using System;
using System.Runtime.Serialization;

namespace Toys
{
    public class ToysException : Exception
    {
        public ToysException()
        {
        }

        public ToysException(string message) : base(message)
        {
        }

        public ToysException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ToysException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
