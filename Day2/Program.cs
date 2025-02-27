namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Assignment 1
            #region
            //// Taking basic salary input
            //Console.Write("Enter Basic Salary: ");
            //double basicSalary = Convert.ToDouble(Console.ReadLine());

            //// Taking performance rating input
            //Console.Write("Enter Performance Rating (0-10): ");
            //double rating = Convert.ToDouble(Console.ReadLine());

            //// Calculate tax deduction (10% of basic salary)
            //double taxDeduction = basicSalary * 0.10;

            //// Calculate bonus based on rating
            //double bonus = 0;
            //if (rating >= 8)
            //{
            //    bonus = basicSalary * 0.20;
            //}
            //else if (rating >= 5)
            //{
            //    bonus = basicSalary * 0.10;
            //}
            //else if(rating<5){
            //    Console.WriteLine("No bonus.");
            //}

            //// Compute net salary
            //double netSalary = basicSalary - taxDeduction + bonus;

            //// Display results
            //Console.WriteLine("\n--- Salary Details ---");
            //Console.WriteLine($"Basic Salary: {basicSalary}");
            //Console.WriteLine($"Tax Deduction (10%): {taxDeduction}");
            //Console.WriteLine($"Bonus: {bonus}");
            //Console.WriteLine($"Net Salary: {netSalary}");
            #endregion

            //Assignment 2
            #region
            //Console.WriteLine("Welcome to Online Train Ticket Booking!");
            //Console.WriteLine("Ticket Types & Prices:");
            //Console.WriteLine("1. General - Rs. 200");
            //Console.WriteLine("2. AC - Rs. 1000");
            //Console.WriteLine("3. Sleeper - Rs. 500");

            //double totalCost = 0;

            //while (true)
            //{
            //    Console.Write("\nEnter Ticket Type (General/AC/Sleeper) or type 'exit' to finish booking: ");
            //    string ticketType = Console.ReadLine().Trim().ToLower();

            //    if (ticketType == "exit")
            //    {
            //        break;
            //    }

            //    Console.Write("Enter the number of tickets: ");
            //    int numberOfTickets;

            //    // Validate input
            //    while (!int.TryParse(Console.ReadLine(), out numberOfTickets) || numberOfTickets <= 0)
            //    {
            //        Console.Write("Invalid input! Please enter a valid number of tickets: ");
            //    }

            //    double ticketPrice = 0;

            //    // Determine ticket price
            //    switch (ticketType)
            //    {
            //        case "general":
            //            ticketPrice = 200;
            //            break;
            //        case "ac":
            //            ticketPrice = 1000;
            //            break;
            //        case "sleeper":
            //            ticketPrice = 500;
            //            break;
            //        default:
            //            Console.WriteLine("Invalid ticket type! Please enter a valid option.");
            //            continue;
            //    }

            //    double cost = ticketPrice * numberOfTickets;
            //    totalCost += cost;

            //    Console.WriteLine($"Booking Confirmed: {numberOfTickets} {ticketType} tickets - Rs. {cost}");
            //}

            //Console.WriteLine($"\nTotal Booking Cost: Rs. {totalCost}");
            //Console.WriteLine("Thank you for using the Online Train Ticket Booking System!");
            #endregion

            //Assignment 3
            //Console.Write(Enter User ID: );
            bool res = false;
            while (!res)
            {
                Console.WriteLine("Enter user id to check wallet Balance");
                double userId = Convert.ToDouble(Console.ReadLine());

                for (int i = 0; i < wallet.GetLength(0); i++)
                {
                    if (wallet[i, 0] == userId)
                    {
                        res = true;
                        Console.WriteLine("Your wallet balace is : " + wallet[i, 1]);
                        break;
                    }
                }
                if (!res)
                {
                    Console.WriteLine("Wrong user Id ");
                }

            }
    }
}
