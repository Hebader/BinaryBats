namespace Grupparbete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }

            public void Input () 
            {
                Username = Console.ReadLine();
                Password = Console.ReadLine();
            }    
        }
    }
}