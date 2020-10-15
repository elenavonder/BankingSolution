using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject
{//SAVINGS CLASS USING INHERITANCE
    class Savings : Account
    {//remember to set it if it is protected
        public double InterestRate { get; protected set; } = 0.01;

        //method to calculate interest rate for 12 months
        public double CalculateInterest(int months)
        {
            return this.Balance * (this.InterestRate / 12) * months;
        }
        //method to deposit the interest rate to exsisting balance
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
        //constructor requiring one parameter calling another constructor in account needing one parameter
        public Savings(string description) : base(description)
        {

        }
        //default constructor, calling other default constructor
        public Savings() : base()
        {

        }
    }
}
