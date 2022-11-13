using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BLL.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException()
        {
        }

        public ValidateException(string message) : base(message)
        {
        }

        public ValidateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
