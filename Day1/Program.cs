namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Assignment 1
            #region Q1
            Console.WriteLine(" enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" enter your HSC Percentage: ");
            double percentage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Student's Name: {name} \t Student's Age: {age} \t Student's HSC Percentage: {percentage}%");
            #endregion

            // Assignment 2
            #region 
            bool isNumeric;
        Age:
            Console.WriteLine("Please enter your age again: ");
            isNumeric = int.TryParse(Console.ReadLine(), out age);
            if (isNumeric == true)
            {
                Console.WriteLine($"Your age is {age}.");
            }
            else
            {
                Console.WriteLine("Bad Input");
                Console.WriteLine("Please enter your age again: ");
                goto Age;
            }
        #endregion


        // Assignment 3
        #region 
        takeMail:
            Console.WriteLine(" enter your email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("enter the email.");
                goto takeMail;
            }
            else
            {
                Console.WriteLine($"Your email is: {email}.");
            }

            #endregion

            //Assignment 4

            #region
            bool isDate;
        Date:
            DateTime dischargeDate;
            Console.WriteLine("Please enter date (MM-DD-YYYY): ");
            isDate = DateTime.TryParse(Console.ReadLine(), out dischargeDate);
            if (isDate == true)
            {
                Console.WriteLine($" Date is: {dischargeDate.ToString("dd/MM/yyyy")}");
            }
            else
            {
                Console.WriteLine("Not Discharged.");
                goto Date;
            }
            #endregion

        }
    }
}
