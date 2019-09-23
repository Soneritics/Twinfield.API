using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Twinfield.API.TwinfieldAPI.Exceptions
{
    class InvalidLoginException : Exception
    {
        public InvalidLoginException()
        {
        }

        protected InvalidLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidLoginException(string message) : base(message)
        {
        }

        public InvalidLoginException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
