using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidPasswordException:Exception
    {
        public string Username { get; }


        public InvalidPasswordException( string username,string? message) : base(message)
        {
            Username = username;
        }

        public InvalidPasswordException(string username,string? message, Exception? innerException) : base(message, innerException)
        {
            Username = username;
        }

        public InvalidPasswordException(string username)
        {
            Username = username;
        }
    }
}