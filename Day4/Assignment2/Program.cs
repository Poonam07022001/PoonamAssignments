using Assignment2.Modal;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("John Doe", 50000);
            emp.DisplayDetails();

            Manager mgr = new Manager("Jane Smith", 80000, 10000);
            mgr.DisplayDetails();
        }
    }
}
