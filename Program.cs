namespace Grupparbete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Input();
            
        }

        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }

            public void Input () 
            {
                Console.WriteLine("Username: ");
                Username = Console.ReadLine();
                Console.WriteLine("Password: ");
                Password = Console.ReadLine();
            }    
        }
    }
}