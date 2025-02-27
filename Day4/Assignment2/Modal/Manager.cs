using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Modal
{
    internal class Manager:Employee
    {
        public double Bonus { get; set; }

        public Manager(string name, double salary, double bonus): base(name, salary)
        {
            Bonus = bonus;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}, Salary: {Salary}, Bonus: {Bonus}");
        }
    }
}
