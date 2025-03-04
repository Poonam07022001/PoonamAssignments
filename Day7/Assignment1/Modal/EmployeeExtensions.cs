using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Modal
{
   static class  EmployeeExtensions
    {
        public static int GetYearsOfExperience(this Employee employee)
        {
           // DateTime currentDate = DateTime.Now;
            DateTime currentDate =new DateTime(2019, 3, 5);
            int yearsOfExperience = currentDate.Year - employee.JoiningDate.Year;

            // Adjust if the joining date hasn't been reached yet this year
            if (currentDate.Month < employee.JoiningDate.Month )
            {
                yearsOfExperience--;
            }

            return yearsOfExperience;
        }
    }
}
