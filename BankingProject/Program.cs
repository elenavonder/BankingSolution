using System;

namespace BankingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var acct1 = new Account();
            acct1.print();
            var acct2 = new Account("MyChecking");
            acct2.print();
            acct2.Deposit(1000);
            acct2.print();
            acct2.Withdraw(50);
            acct2.print();
            try
            {
                acct2.Deposit(-200);
                acct2.print();
                acct2.Withdraw(-200);
                acct2.print();
            } catch (Exception ex)//Exception is type ex is variable
            {
                Console.WriteLine(ex.Message);
            }
            var success = Account.Transfer(200, acct2, acct1);
            if (success)
            {
                Console.WriteLine("Your transfer worked");
            }
            else
            {
                Console.WriteLine("your transfer failed");
            }
            acct2.print();
            acct1.print();
        }
    }
}
