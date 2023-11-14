using System;
using System.Reflection.Metadata;

namespace Grupparbete
{
    internal class Program : Owner
    {
        private int maxAttempts = 3;
        private int adminAttempts = 0;
        private int userAttempts = 0;
        public void Run()
        {

            while (true)
            {
                Console.Write("Enter your choice, 1, 2 or 3: ");
                Console.WriteLine("1. Select Admin login");
                Console.WriteLine("2. Select User Login");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdminLogin();
                        break;

                    case "2":
                        UserLogin();
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
        private void AdminLogin()
        {
            string Username;
            string Password;

            Console.WriteLine("Username: ");
            Username = Console.ReadLine();
            Console.WriteLine("Password: ");
            Password = Console.ReadLine();
        }

        private void UserLogin()
        {
            string Username;
            string Password;

            Console.WriteLine("Username: ");
            Username = Console.ReadLine();
            Console.WriteLine("Password: ");
            Password = Console.ReadLine();
        }


        static void Main(string[] args)
        {
            Program user = new Program();
            user.Id = 1;
            user.Run();


            Admin user2 = new Admin();
            user2.Id = 2;

            List<Owner> mylist = new List<Owner>();
            mylist.Add(user);
            mylist.Add(user2);
        }
    }

    public class Login
    {


    }

    public class Owner : Login
    {
        public int Id { get; set; }


    }

    public class User : Owner
    {

    }
    public class Admin : Owner
    {

    }
}
