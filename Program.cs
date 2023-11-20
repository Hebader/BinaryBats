using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection.Metadata;

namespace Grupparbete

{

    internal class Program

    {

        static void Main(string[] args)

        {

            Program program = new Program();

            program.RunApplication();

        }

        public void Run()
        {
            LoginManager loginManager = new LoginManager();
            
            while (true)
            {
                Console.WriteLine("1. Admin login");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice, 1, 2, or 3: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        adminLogin(loginManager);
                        break;

                    case "2":
                        userLogin(loginManager);
                        break;

                    case "3":
                        Console.WriteLine("Exiting program.");
                        Environment.Exit(0); // en metod som asvlutar programmet
                        break; 

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
               
            } 
            
        }

        public void adminLogin(LoginManager loginManager)
        {
            for (int attempts = 1; attempts <= 3; attempts++)
            {
                string enterdUsername;
                string enterdPassword;

                if (loginManager.tryLogin("admin", "123", out enterdUsername, out enterdPassword))
                {

                    Console.WriteLine("Successful login!");

                    AdminMenu(); //Om inloggningen lyckas går den till Admin meny

                }
                else if (attempts < 3)
                {

                    Console.WriteLine($"Invalid credentials. Login Attempts left: {loginManager.maxAttempts - attempts}");

                }
                else
                {

                    Console.WriteLine("Too many failed login attempts. Account has been locked");


                }



            }
           
           
        }
        public void userLogin(LoginManager loginManager)
        {
            for (int attempts = 1; attempts <= 3; attempts++)
            {
                string enterdUsername;
                string enterdPassword;


                if (loginManager.tryLogin("user", "123", out enterdUsername, out enterdPassword))
                {
                    Console.WriteLine("Successful login!");


                    UserMenu(); //Om inloggningen lyckas går den till Admin meny

                }
                else if (attempts < 3)
                {

                    Console.WriteLine($"Invalid credentials. Login Attempts left: {loginManager.maxAttempts - attempts}");

                }
                else 
                {

                    Console.WriteLine("Too many failed login attempts. Account has been locked");


                }
               


            }
           


        }

        public void AdminMenu()
        {
            
            while (true)
            {
                Console.WriteLine("1. Add user");
                Console.WriteLine("2. Logout");

                Console.WriteLine("Choose between 1 or 2");
                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        AddUser();
                        break;

                    case 2:
                        return; //logga ut


                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        void UserMenu()

        { //Lagt till en Usermenu och loopat
            while (true)

            {

                //Console.WriteLine("1. Add user");

                Console.WriteLine("1. Check saldo");

                Console.WriteLine("2. Transfer money");

                Console.WriteLine("3. Logout");

                Console.WriteLine("Choose between 1, 2 or 3");

                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)

                {

                    case 1:

                        CheckSaldo();

                        break;

                    case 2:

                        TransferMethod();
                        break;

                    case 3:
                        return; // Logout option

                    default:

                        Console.WriteLine("Invalid choice. Please enter a valid option.");

                        break;

                }

            }

        }

        List<BankAccount> CreateBankAccounts()

        {

            List<BankAccount> userAccounts = new List<BankAccount>();

            BankAccount acoount1 = new BankAccount("173556889", 20000);

            BankAccount acoount2 = new BankAccount("587654321", 3000);

            BankAccount acoount3 = new BankAccount("146853522", 2000);

            userAccounts.Add(acoount1);

            userAccounts.Add(acoount2);

            userAccounts.Add(acoount3);


            return userAccounts;

        }

        

        private void DisplayUserAccounts(List<BankAccount> accounts)

        {

            Console.WriteLine("Your bankaccounts and salary:");

            foreach (var account in accounts)

            {

                Console.WriteLine($"Bankaccount: {account.AccountNumber}, Salary: {account.Balance:C}");

            }


        }

        void CheckSaldo()
        {
            List<BankAccount> userAccounts = CreateBankAccounts();

            DisplayUserAccounts(userAccounts);

        }

        void AddUser()

        {

            List<string> userList = new List<string>();

            while (true)

            {

                Console.WriteLine("Do you want to add a user? yes/no ");

                string answer = Console.ReadLine();

                if (answer == "yes")

                {

                    Console.WriteLine("Write username: ");

                    string userName = Console.ReadLine();

                    userList.Add(userName);

                    Console.WriteLine("User is added");

                    Console.WriteLine("\n Userlist:");

                    foreach (var user in userList)

                    {

                        Console.WriteLine(user);

                    }

                }

                else if (answer.ToLower() == "no")

                {

                    break;

                }

            }

        }
        void TransferMethod()
        {
            List<BankAccount> userAccounts = CreateBankAccounts();

            while (true)

            {

                Console.WriteLine("do you want to transfer? yes/no ");

                string answer = Console.ReadLine();

                if (answer == "yes")

                {

                    if (userAccounts.Count >= 2) //Om det finns minst två konton eller fler

                    {

                        BankAccount sourceAccount = userAccounts[0];
                        BankAccount destinationAccount = userAccounts[1];

                        Console.WriteLine("transfer...");
                        sourceAccount.Transfer(destinationAccount);

                        
                        Console.WriteLine("Updated account balances after transfer:");
                        DisplayUserAccounts(userAccounts);

                    }

                    break;

                }

                else if (answer == "no")

                {
                   
                    break;

                }

            }
        }


        public void RunApplication()

        {
            LoginManager loginManager = new LoginManager();
           
            Run();

            adminLogin(loginManager);

            

        }

    }

}
