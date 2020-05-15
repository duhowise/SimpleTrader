using System;
using System.Runtime.Serialization;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidSymbolException:Exception
    {
        private readonly string _symbol;

        public InvalidSymbolException(string symbol)
        {
            _symbol = symbol;
        }

        public InvalidSymbolException(string symbol ,string message):base(message)
        {
            _symbol = symbol;
        }

        public InvalidSymbolException(Exception innerException, string message, string symbol):base(message,innerException)
        {
            _symbol = symbol;
        }
    }
}