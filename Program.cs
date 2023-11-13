using System.Reflection.Metadata;

namespace Grupparbete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Login user = new Login();
            user.Input();
            
        }

        public class Login
        {
            public string Username { get; set; }
            public string Password { get; set; }

            public string Input () 
            {
                    Console.WriteLine("Username: ");
                    Username = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    Password = Console.ReadLine();
                
                return Username;
                return Password;
            }    

        }

        public class User
        {

        }
        public class Admin
        {

        }
    }
}