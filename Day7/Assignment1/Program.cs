using Assignment1.Modal;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("John Doe", new DateTime(2018, 12, 1));
            Console.WriteLine($"{emp.Name} has {emp.GetYearsOfExperience()} years of experience.");
        }
    }
}
