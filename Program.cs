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

        private int maxAttempts = 3;

        private int adminAttempts = 0;

        private int userAttempts = 0;

        public void Run()

        {

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

                        adminLogin();

                        if (true)

                        {

                            AdminMenu();

                        }

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

            }

        }

        public void adminLogin()

        {

            if (adminAttempts < maxAttempts)

            {

                if (checkAdmin())

                {

                    Console.WriteLine("Successful login!");

                    AdminMenu(); //Om inloggningen lyckas går den till Admin meny

                }

                else

                {

                    adminAttempts++;

                    Console.WriteLine($"Invalid credentials. Login Attempts left: {maxAttempts - adminAttempts}");

                }

            }

            else

            {

                Console.WriteLine("Too many failed login attempts. Account has been locked");

            }

        }

        void userLogin()

        {

            if (userAttempts < maxAttempts)

            {

                if (checkUser())

                {

                    Console.WriteLine("Successful login!");

                    UserMenu(); //Lagt in meny för user som i "Adminmenyn"

                }

                else

                {

                    userAttempts++;

                    Console.WriteLine($"Invalid credentials. Attempts left: {maxAttempts - userAttempts}");

                }

            }

            else

            {

                Console.WriteLine("Too many failed login attempts. Account has been locked");

            }

        }

        bool checkAdmin()

        {

            Console.Write("Username: ");

            string adminUsername = Console.ReadLine();

            Console.Write("Password: ");

            string adminPassword = Console.ReadLine();

            return adminUsername == "admin" && adminPassword == "123";

        }

        bool checkUser()

        {

            Console.Write("Username: ");

            string userUsername = Console.ReadLine();

            Console.Write("Password: ");

            string userPassword = Console.ReadLine();

            return userUsername == "user" && userPassword == "123";

        }

        void UserMenu()

        { //Lagt till en Usermenu och loopat

            while (true)

            {

                //Console.WriteLine("1. Add user");

                Console.WriteLine("1. Check saldo");

                Console.WriteLine("2. Logout");

                Console.WriteLine("Choose between 1 or 2");

                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)

                {

                    // case 1:

                    // AddUser();

                    // break;

                    case 1:

                        CreateBankAccounts();

                        break;

                    case 2:

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

        List<BankAccount> AdminBankAccounts()

        { //Lagt till en lista med bankkonto för admin

            List<BankAccount> userAccounts = new List<BankAccount>();

            userAccounts.Add(new BankAccount("463718293", 20000));

            userAccounts.Add(new BankAccount("175019005", 3000));

            userAccounts.Add(new BankAccount("658392098", 2000));

            // Lägg till  add här

            return userAccounts;

        }

        private void DisplayUserAccounts(List<BankAccount> accounts)

        {

            if (checkUser()) // körs bara om man loggar in som user

            {

                Console.WriteLine("Your bankaccounts and salary:");

                foreach (var account in accounts)

                {

                    Console.WriteLine($"Bankaccount: {account.AccountNumber}, Salary: {account.Balance:C}");

                }

            }

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

        public void RunApplication()

        {

            Run();

            adminLogin();

            List<BankAccount> userAccounts = CreateBankAccounts();

            DisplayUserAccounts(userAccounts);

            while (true)

            {

                Console.WriteLine("do you want to transfer? yes/no ");

                string answer = Console.ReadLine();

                if (answer == "yes")

                {

                    if (userAccounts.Count >= 2) //Om det finns minst två konton eller fler

                    {

                        BankAccount sourceAccount = userAccounts[0]; // skapar en variabel örsta kontot

                        BankAccount destinationAccount = userAccounts[1]; // Andra kontot

                        Console.WriteLine("transfer...");

                        sourceAccount.Transfer(destinationAccount); // Gör överföringen mellan första och andra kontot

                        Console.WriteLine("Updated account balances after transfer:");

                        DisplayUserAccounts(userAccounts); // Utskrift av nya saldon

                    }

                    break;

                }

                else if (answer == "no")

                {

                    break;

                }

            }

            while (true)

            {

                Console.WriteLine("Enter your role: Admin or User");

                string role = Console.ReadLine().ToLower();

                switch (role)

                {

                    case "admin":

                        adminLogin();

                        AdminMenu();

                        break;

                    case "user":

                        userLogin();

                        UserMenu();

                        break;

                    default:

                        Console.WriteLine("Invalid role. Please enter either 'Admin' or 'User'.");

                        break;

                }

            }

        }

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

}

/*   class BankAccount

  {

      public string AccountNumber { get; } //Vill få värdet men inte kunna ändra

      public decimal Balance { get; set; } // Värdet kan ändras med set
 
          adminLogin();

          List<BankAccount> userAccounts = CreateBankAccounts();

          DisplayUserAccounts(userAccounts);
 
          while (true)

          {

              Console.WriteLine("do you want to transfer? yes/no ");
 
              string answer = Console.ReadLine();

              //

              if (answer == "yes")

              {

                  if (userAccounts.Count >= 2) //Om det finns minst två konton eller fler

                  {

                      BankAccount sourceAccount = userAccounts[0]; // skapar en variabel örsta kontot

                      BankAccount destinationAccount = userAccounts[1]; // Andra kontot
 
                      Console.WriteLine("transfer...");

                      sourceAccount.Transfer(destinationAccount); // Gör överföringen mellan första och andra kontot

                      Console.WriteLine("Updated account balances after transfer:");

                      DisplayUserAccounts(userAccounts); // Utskrift av nya saldon

                  }
 
                  break;
 
              }

              else if (answer == "no")

              {

                  break;

              }
 
          }
 
 
/*while (true)

{

    Console.WriteLine("do you want to transfer? yes/no ");
 
    string answer = Console.ReadLine();
 
    if (answer == "yes")

    {

        if (userAccounts.Count >= 2) //Om det finns minst två konton eller fler

        {

            BankAccount sourceAccount = userAccounts[0]; // skapar en variabel örsta kontot

            BankAccount destinationAccount = userAccounts[1]; // Andra kontot
 
            Console.WriteLine("transfer...");

            sourceAccount.Transfer(destinationAccount); // Gör överföringen mellan första och andra kontot

            Console.WriteLine("Updated account balances after transfer:");

            DisplayUserAccounts(userAccounts); // Utskrift av nya saldon

        }
 
        break;
 
    }

    else if (answer == "no")

    {

        break;

    }
 
} */