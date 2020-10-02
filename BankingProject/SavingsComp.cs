using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BankingProject
{
    class SavingsComp
    {
        public Account account { get; private set; } = null;
        public double InterestRate { get; private set; } = 0.01;
        //All this can be in interface  
        public static bool Transfer (double amount, SavingsComp FromAccount, Account ToAccount)
        {
            return Account.Transfer(amount, FromAccount.account, ToAccount);
        }
        public static bool Transfer(double amount, Account FromAccount, SavingsComp ToAccount)
        {
            return Account.Transfer(amount, FromAccount, ToAccount.account);
        }
        public static bool Transfer(double amount, SavingsComp FromAccount, SavingsComp ToAccount)
        {
            return Account.Transfer(amount, FromAccount.account, ToAccount.account);
        } 
        public double Deposit(double amount)
        {
            return this.account.Deposit(amount);
        }
        public double Withdraw (double amount)
        {
            return this.account.Withdraw(amount);
        }
        public double CalculateInterest(int months)
        {
            return this.account.Balance * (this.InterestRate / 12) * months;
        }
        public double PayInterest(int months)
        {
            var interest = this.CalculateInterest(months);
            account.Deposit(interest);
            return interest;
        }

        public void print()
        {
            Console.WriteLine($"IntRate: [{this.InterestRate}], Balance: [{account.Balance}], Description: [{account.Description}]");
        }

        public SavingsComp(Double intrate, string description)
        {
            this.account = new Account(description);//call the account constructor first
            this.InterestRate = intrate;//part of creating new one
        }
        public SavingsComp(string description)
        {
            this.account = new Account(description);
        }
        public SavingsComp()
        {
            this.account = new Account();
        }
    }
}
