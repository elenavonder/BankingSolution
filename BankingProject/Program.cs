using BankingProject.Exceptions;
using System;

namespace BankingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var sav1 = new Savings(0.12, "My Savings");
            sav1.Deposit(1000);
            sav1.print();
            sav1.PayInterest(1);
            sav1.print();

            var sav2 = new SavingsComp(0.12, "My Composite Savings");
            sav2.Deposit(1000);
            sav2.print();
            sav2.PayInterest(1);
            sav2.print();

                var acct1 = new Account();
                acct1.print();
                var acct2 = new Account("MyChecking");
                acct2.print();
                acct2.Deposit(1000);
                acct2.print();
            try { 
                acct2.Withdraw(5000);
                acct2.print();
                acct2.Deposit(-200);
                acct2.print();
                acct2.Withdraw(-200);
                acct2.print();
            }
            catch(InsufficientFundsExceptions ex)
            {
                Console.WriteLine($"Insufficient Funds: Acct: {ex.AccountId}, Amt: {ex.AmountWithdraw}, Bal: {ex.Balance}");
            }
            catch (DivideByZeroException ex)//Exception is type ex is variable
            {
                Console.WriteLine("Attempted to divide by zero");
            }
            catch (Exception ex)
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
