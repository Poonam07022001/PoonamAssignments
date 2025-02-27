using System.Text.RegularExpressions;

namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                string validationMessage = ValidatePassword(password);

                Console.WriteLine(validationMessage);
                Console.ReadLine();
            }

            static string ValidatePassword(string password)
            {
                if (password.Length < 6)
                {
                    return "❌ Password must be at least 6 characters long.";
                }
                if (!Regex.IsMatch(password, @"[A-Z]"))
                {
                    return "❌ Password must contain at least one uppercase letter.";
                }
                if (!Regex.IsMatch(password, @"\d"))
                {
                    return "❌ Password must contain at least one digit.";
                }
                return "✅ Password is valid!";
            }
        }
    }
}
