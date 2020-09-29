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
        }
    }
}
