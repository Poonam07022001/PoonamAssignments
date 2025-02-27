using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Modal
{
    internal class User
    {
        static int UserIncerement;
       public User() {
            UserIncerement++;
        }

        public void UserIncrement() {
            Console.WriteLine($"User::{UserIncerement}");
        }

    }
}
