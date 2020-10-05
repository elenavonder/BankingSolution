using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BankingProject.Exceptions
{
    class InsufficientFundsExceptions : Exception
    {
        public int AccountId { get; set; }
        public double AmountWithdraw { get; set; }
        public double Balance { get; set; }

        public InsufficientFundsExceptions (string message, Exception innerException)
            : base (message, innerException)
        {

        }
        public InsufficientFundsExceptions (string message) : base(message)
        {
                
        }
        public InsufficientFundsExceptions () : base()
        {

        }
    }
}
