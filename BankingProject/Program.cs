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
            acct2.Deposit(-200);
            acct2.print();
            acct2.Withdraw(-1);
            acct2.print();
        }
    }
}
