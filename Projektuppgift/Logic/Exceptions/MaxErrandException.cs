using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Exceptions
{
    public class MaxErrandException : Exception
    {
        public MaxErrandException()
        {

        }

        public MaxErrandException(string message) : base(message)
        {

        }

        public MaxErrandException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}