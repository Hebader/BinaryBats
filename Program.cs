using System;
using System.Reflection.Metadata;

namespace Grupparbete
{
    internal class Program :Owner
    {
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
            }
        }
        private void adminLogin()
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
            user.Id = 1;
            user.Run();


            Program user2 = new Program();
            user2.Id = 2;
            user.Run();

            List<Owner> mylist = new List<Owner>();
            mylist.Add(user);
            mylist.Add(user2);
        }
    }

 

    public class Owner
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
