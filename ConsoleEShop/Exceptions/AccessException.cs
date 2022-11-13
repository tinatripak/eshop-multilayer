using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleEShop.Exceptions
{
    /// <summary>
    /// Exception of access
    /// </summary>
    public class AccessException : Exception
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public AccessException()
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        public AccessException(string message) : base(message)
        {
        }
    }
}
