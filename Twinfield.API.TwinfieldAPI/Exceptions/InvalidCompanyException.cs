using System;
using System.Runtime.Serialization;

namespace Twinfield.API.TwinfieldAPI.Exceptions
{
    class InvalidCompanyException : Exception
    {
        public InvalidCompanyException()
        {
        }

        protected InvalidCompanyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidCompanyException(string message) : base(message)
        {
        }

        public InvalidCompanyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
