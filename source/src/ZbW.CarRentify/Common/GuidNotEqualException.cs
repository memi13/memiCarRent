using System;
using System.Runtime.Serialization;

namespace ZbW.CarRentify.Common
{
    public class GuidNotEqualException : Exception
    {
        public GuidNotEqualException()
        {
        }

        public GuidNotEqualException(string message) : base(message)
        {
        }

        public GuidNotEqualException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GuidNotEqualException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}