using System;
using System.Runtime.Serialization;

namespace SimpleTrader.Domain.Exceptions
{
    public class InsufficientFundsException:Exception
    {
        public double AccountBalance { get; set; }
        public double RequiredBalance { get; set; }
        public InsufficientFundsException(double requiredBalance, double accountBalance)
        {
            RequiredBalance = requiredBalance;
            AccountBalance = accountBalance;
        }

       

        public InsufficientFundsException(string? message, double requiredBalance, double accountBalance) : base(message)
        {
            RequiredBalance = requiredBalance;
            AccountBalance = accountBalance;
        }

        public InsufficientFundsException(string? message, Exception? innerException, double requiredBalance, double accountBalance) : base(message, innerException)
        {
            RequiredBalance = requiredBalance;
            AccountBalance = accountBalance;
        }
    }
}