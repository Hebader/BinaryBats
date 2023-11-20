using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete
{
    internal class LoginManager
    {

        public int maxAttempts = 3;

        public int Attempts = 0;

        public bool tryLogin(string username, string password, out string enterdUsername, out string entredPassword)
        {
            Console.Write("Username: ");
            enterdUsername = Console.ReadLine();

            Console.Write("Password: ");
            entredPassword = Console.ReadLine();

            return Attempts <= maxAttempts && enterdUsername == username && entredPassword == password;
        }

    }
}
