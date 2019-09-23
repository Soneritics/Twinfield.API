using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Twinfield.API.TwinfieldAPI.Exceptions
{
    class UnknownValueTypeException : Exception
    {
        public UnknownValueTypeException()
        {
        }

        protected UnknownValueTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnknownValueTypeException(string message) : base(message)
        {
        }

        public UnknownValueTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
