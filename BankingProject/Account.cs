using System;
using System.Collections.Generic;
using System.Text;
using BankingProject.Exceptions;

namespace BankingProject
{
    class Account
    {
        //makes all Ids = 1 instead of starting at 0
        private static int NextId = 1;
        public int Id { get; private set; }
        //makes balance 0
        public  double Balance { get; private set; } = 0;
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

        //tranfer method
        public static bool Transfer (double amount, Account FromAccount, Account ToAccount)
        {
            //amount can't be less than 0
            if(amount <= 0)
            {
                return false;
            }//account able to be null, need to catch it
            if (FromAccount == null || ToAccount == null)
            {
                return false;
            }//finding before and after balance using the INSTANCE of the TO and FROM Account with Deposit and Withdraw method
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
        {//(amount <= 0) was original double code
            if (!CheckAmountGreaterThanZero(amount)) 
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
                //this is an exception incase negatives or nulls are in accounts or balances
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

        //method that doesn't return anything/ shortcut for console writeline
        public void print()
        {
            Console.WriteLine($"Id: [{Id}], Balance: [{Balance}], Description: [{Description}]");
        }
        //constuctor generating new Id
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
