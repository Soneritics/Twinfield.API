using System;
using System.Runtime.Serialization;

namespace Api.Exceptions
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
