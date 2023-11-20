using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete
{
    class BankAccount
    {

        public string AccountNumber { get; } //Vill få värdet men inte kunna ändra

        public decimal Balance { get; set; } // Värdet kan ändras med set

        public BankAccount(string accountNumber, decimal balance) //Konstruktor för kontonmr och saldo

        {

            AccountNumber = accountNumber;

            Balance = balance;

        }

        public void Transfer(BankAccount destination)

        {

            Console.WriteLine("how much do you want to transfer?");

            decimal amount = decimal.Parse(Console.ReadLine()); //TODO: error handling

            if (amount > 0 && Balance >= amount)

            {

                destination.Balance = destination.Balance + amount;

                Balance = Balance - amount;

                Console.WriteLine($"transfer successful! {amount} transferd");

            }

            else

            {

                Console.WriteLine("transfer failed!");

            }



        }

    }
}
