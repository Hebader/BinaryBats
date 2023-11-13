using System.Reflection.Metadata;

namespace Grupparbete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Owner user = new Owner();
            user.Id = 1;
            user.Input();

            Owner user2 = new Owner();
            user.Id = 2;

            List<Owner>mylist = new List<Owner>();  
            mylist.Add(user);
            mylist.Add(user2);


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

        public class Owner : Login
        {
           public int Id { get; set; }

           
        }

        public class User: Owner
        {

        }
        public class Admin: Owner
        {

        }
    }
}