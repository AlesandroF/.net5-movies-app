using System;

namespace Domain.Exceptions
{
    public class DomainException : Exception
    {
        public string Error;

        public DomainException(string message) : base(message)
        {
            Error = message;
        }
    }
}