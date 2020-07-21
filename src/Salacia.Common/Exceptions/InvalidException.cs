using System;

namespace Salacia.Common.Exceptions
{
    public class InvalidException : Exception
    {
        public InvalidException(string message) : base(message)
        {
        }
    }
}