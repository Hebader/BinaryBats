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
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        public void adminLogin(LoginManager loginManager)
        {
            string enterdUsername;
            string enterdPassword;

            if (loginManager.tryLogin("admin", "123", out enterdUsername, out enterdPassword))
            {

                Console.WriteLine("Successful login!");

                AdminMenu(); //Om inloggningen lyckas går den till Admin meny

            }
            else
            {

                Console.WriteLine($"Invalid credentials. Login Attempts left: {loginManager.maxAttempts - loginManager.Attempts}");

            }
            if (loginManager.maxAttempts == 3)
            {

                Console.WriteLine("Too many failed login attempts. Account has been locked");

            }

        }
        public void userLogin(LoginManager loginManager)
        {
            string enterdUsername;
            string enterdPassword;

            if (loginManager.tryLogin("user", "123", out enterdUsername, out enterdPassword))
            {
                Console.WriteLine("Successful login!");

                UserMenu(); //Om inloggningen lyckas går den till Admin meny

            }
            else
            {

                Console.WriteLine($"Invalid credentials. Login Attempts left: {loginManager.maxAttempts - loginManager.Attempts}");

            }
            if (loginManager.maxAttempts == 3)
            {

                Console.WriteLine("Too many failed login attempts. Account has been locked");

            }

        }

        public void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Add user");
                Console.WriteLine("2. Check saldo");
                Console.WriteLine("3. Logout");

                Console.WriteLine("Choose between 1, 2, or 3");
                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        AddUser();
                        break;

                    case 2:
                        AdminBankAccounts();
                        break;

                    case 3:
                        return; // Logga ut

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

                        List<BankAccount> userAccounts = CreateBankAccounts();

                        DisplayUserAccounts(userAccounts);

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

            Console.WriteLine("Your bankaccounts and salary:");

            foreach (var account in accounts)

            {

                Console.WriteLine($"Bankaccount: {account.AccountNumber}, Salary: {account.Balance:C}");

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
        void TransferMethod()
        {
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
        
            
            // hej hej
            while (true)

            {

                Console.WriteLine("Enter your role: Admin or User");

                string role = Console.ReadLine().ToLower();

                switch (role)

                {

                    case "admin":

                        adminLogin(loginManager);

                        AdminMenu();

                        break;

                    case "user":

                        userLogin(loginManager);

                        UserMenu();

                        break;

                    default:

                        Console.WriteLine("Invalid role. Please enter either 'Admin' or 'User'.");

                        break;

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