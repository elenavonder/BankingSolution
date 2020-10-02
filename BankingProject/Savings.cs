using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject
{
    class Savings : Account
    {
        public double InterestRate { get; protected set; } = 0.01;//remember to set it if it is protected

        public double CalculateInterest(int months)
        {
            return this.Balance * (this.InterestRate / 12) * months;
        }
        public double PayInterest (int months)
        {
            var interest = this.CalculateInterest(months);
            Deposit(interest);
            return interest;
        }

        public Savings (double intrate, string description) : base (description)
        {
            this.InterestRate = intrate;
        }
        public Savings(string description) : base(description)
        {

        }
        public Savings() : base()
        {

        }
    }
}
