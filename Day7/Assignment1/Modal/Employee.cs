using System;
using System.Collections.Generic;


namespace Assignment1.Modal
{
    class Employee
    {
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }

        public Employee(string name,DateTime joiningDate)
        {
            Name = name;
            JoiningDate = joiningDate;
        }
    }

   
}
