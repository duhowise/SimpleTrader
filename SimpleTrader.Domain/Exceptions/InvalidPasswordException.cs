using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidPasswordException:Exception
    {
        private readonly string _username;

      
        public InvalidPasswordException( string username,string? message) : base(message)
        {
            _username = username;
        }

        public InvalidPasswordException(string username,string? message, Exception? innerException) : base(message, innerException)
        {
            _username = username;
        }

        public InvalidPasswordException(string username)
        {
            _username = username;
        }
    }
}