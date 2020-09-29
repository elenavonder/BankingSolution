using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject
{
    class Account
    {
        private static int NextId = 1;
        public int Id { get; private set; }
        public double Balance { get; private set; } = 0;//to set balance to 0
        public string Description { get; set; }

        public double Deposit (double amount)
        {
            Balance = Balance + amount;
            return Balance;
        }

        public double Withdraw(double amount)
        {
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
         //Without : this("New Account"), the Id won't change.
         //By doing this, you tell it what construct to use.
        }
    }
}
