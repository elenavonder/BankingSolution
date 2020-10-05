using System;
using System.Collections.Generic;
using System.Text;
using BankingProject.Exceptions;

namespace BankingProject
{
    class Account
    {
        private static int NextId = 1;
        public int Id { get; private set; }
        public  double Balance { get; private set; } = 0;//to set balance to 0
        public string Description { get; set; }

        //Hard way
        private bool CheckAmountGreaterThanZero(double amount)
        {
            if (amount <= 0)
            {
                //Console.WriteLine("Amount must be greater than 0");
                throw new Exception("Amount must be greater than 0");
               //return false;
            }
            return true;
        }

        public static bool Transfer (double amount, Account FromAccount, Account ToAccount)
        {
            if(amount <= 0)
            {
                return false;
            }
            if (FromAccount == null || ToAccount == null)
            {
                return false;
            }
            var BeforeBalance = FromAccount.Balance;
            var AfterBalance = FromAccount.Withdraw(amount);
            if (BeforeBalance != AfterBalance + amount)
            {
                return false;
            }
            ToAccount.Deposit(amount);
            return true;
        }
        //static/class method (more error prone because class is a type and types can be null)
        public static double Deposit (double amount, Account acct)
        {
            return acct.Deposit(amount);
        }
        //instance method
        public double Deposit (double amount)
        {
            if (!CheckAmountGreaterThanZero(amount)) //(amount <= 0) was original double code
            {
                return Balance;
            }
            Balance = Balance + amount;
            return Balance;
        }

        public double Withdraw(double amount)
        {
            if(!CheckAmountGreaterThanZero(amount)) //(amount <=0) was original double code
            {
                return Balance;
            }
            if(Balance < amount)
            {
                var isfex = new InsufficientFundsExceptions();
                isfex.AccountId = this.Id;
                isfex.AmountWithdraw = amount;
                isfex.Balance = this.Balance;
                throw isfex;
            }
            //same as Balance = Balance - amount;
            Balance -= amount; 
            return Balance;
        }


        public void print()
        {
            Console.WriteLine($"Id: [{Id}], Balance: [{Balance}], Description: [{Description}]");
        }
        public Account (string description)
        {
            this.Id = NextId++;
            this.Description = description;
        }
        //There is only one parameter (string) in the contruct above, need one below
        public Account() : this("New Account") 
        {
         // : this()  is pointing to a certain constructor
         //By doing this, you tell it what construct to use.
        }
    }
}
