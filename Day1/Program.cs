namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter name of the Student :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age of the Student :");
            int age;
            bool res;
            res = int.TryParse(Console.ReadLine(), out age);

            while (!res)
            {
                Console.WriteLine("Enter a valid age!!!");
                res = int.TryParse(Console.ReadLine(), out age);

            }
            Console.WriteLine("Enter percentage of the Student :");

            double percentage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($" Name :{name}    Age :{age}   Percentage :{percentage}%");

            Console.WriteLine("Enter your email :");
            string email = Console.ReadLine();
            while (email == "")
            {
                Console.WriteLine("Email  can't be empty!!");
                email = Console.ReadLine();

            }

            Console.WriteLine($"Email :{email}");

            string? date = "12/2/2024";

            if (date != null)
            {
                Console.WriteLine("Person discharged");

            }
            else
            {
                Console.WriteLine("Not Discharged");
            }

        }
    }
}
