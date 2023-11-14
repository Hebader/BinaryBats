using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

namespace Grupparbete
{
    internal class Program //
    {
        private int maxAttempts = 3;
        private int adminAttempts = 0;
        private int userAttempts = 0;
        
        public void Run()
        {

            bool condition = true;
            while (true)
            {
               
                Console.WriteLine("1. Admin login");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice, 1, 2 or 3: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        adminLogin();
                        break;


                    case "2":
                        userLogin();
                        break;

                    case "3":
                        Console.WriteLine("Exiting program.");     
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
                if (condition)
                {
                    break; // Loopen avbryts om villkoret har uppfyllts 
                }
            }
        }
        public void adminLogin()
        {
            if (adminAttempts < maxAttempts)
            {
                if (checkAdmin())
                {
                    Console.WriteLine("Successful login!");
                }
                else
                {
                    adminAttempts++;
                    Console.WriteLine($"Invalid  credentials. Login Attempts left: {maxAttempts - adminAttempts}");
                }
            }
            else
            {
                Console.WriteLine("Too many failed login attemps. Account has been locked");
            }

            AddUser(); // Method for adding users

            static void Menu()
            {

                Console.WriteLine("1. add user");
                Console.WriteLine("2. check saldo");

                Console.WriteLine("choose between 1,2,3");
                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        AddUser();
                        break;

                    case 2:
                        break;


                }
            }

            static void AddUser()
            {
                List<string> userList = new List<string>();

                while (true)
                {
                    Console.WriteLine("do you want to add a user? yes/no ");

                    string answer = Console.ReadLine();

                    if (answer == "yes")
                    {
                        Console.WriteLine("write username: ");
                        string userName = Console.ReadLine();

                        userList.Add(userName);

                        Console.WriteLine("user is added");
                        break;

                    }
                    else if (answer == "no")
                    {
                        break;
                    }

                }

                Console.WriteLine("\n userlist: ");
                foreach (var user in userList)
                {
                    Console.WriteLine(user);
                }
            }
        }
        private bool checkAdmin()
        {
            Console.Write("Username: ");
            string adminUsername = Console.ReadLine();

            Console.Write("Password: ");
            string adminPassword = Console.ReadLine();

            return adminUsername == "admin" && adminPassword == "123";

        }


        private void userLogin()
        {
            if (userAttempts < maxAttempts)
            {
                if (checkUser())
                {
                    Console.WriteLine("Successful login!");
                }
                else
                {
                    userAttempts++;
                    Console.WriteLine($"Invalid credentials. Attempts left: {maxAttempts - userAttempts}");
                }
            }
            else
            {
                Console.WriteLine("Too many failed login attemps. Account has been locked");
            }
        }
        private bool checkUser()
        {
            Console.Write("Username: ");
            string userUsername = Console.ReadLine();

            Console.Write("Password: ");
            string userPassword = Console.ReadLine();

            return userUsername == "user" && userPassword == "123";
        }


        static void Main(string[] args)
        {
            Program user = new Program();
            user.Run();
            user.adminLogin();

        List<BankAccount> userAccounts = new List<BankAccount>();
        userAccounts.Add(new BankAccount("173556889", 20000));
        userAccounts.Add(new BankAccount("587654321", 3000));
        userAccounts.Add(new BankAccount("146853522", 2000));

                DisplayUserAccounts(userAccounts);
            }

            static void DisplayUserAccounts(List<BankAccount> accounts)
            {
                Console.WriteLine("Your bankaccount and salary:");
                foreach (var account in accounts)
                {
                    Console.WriteLine($"Bankaccount: {account.AccountNumber}, Salary: {account.Balance:C}");
                }
            }
            //List<Owner> mylist = new List<Owner>();
            //mylist.Add(user);
            //mylist.Add(user2);
        }

        class BankAccount
        {
            public string AccountNumber { get; }
            public decimal Balance { get; set; }

            public BankAccount(string accountNumber, decimal balance)
            {
                AccountNumber = accountNumber;
                Balance = balance;
            }
        }
    }



    //public class Login
    //{


//}

//public class Owner : Login
//{
//    public int Id { get; set; }


//}

//public class User : Owner
//{

//}
//public class Admin : Owner
//{

//}