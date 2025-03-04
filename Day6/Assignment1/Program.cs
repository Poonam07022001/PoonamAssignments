namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customerQueue = new Queue<string>(); // Queue to store customers

            while (true)
            {
                Console.WriteLine("\nBank Token System");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Serve Customer");
                Console.WriteLine("3. Check Next Customer");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter customer name: ");
                        string customerName = Console.ReadLine();
                        customerQueue.Enqueue(customerName);
                        Console.WriteLine($"{customerName} has taken a token.");
                        break;

                    case "2":
                        if (customerQueue.Count > 0)
                        {
                            string servedCustomer = customerQueue.Dequeue();
                            Console.WriteLine($"{servedCustomer} has been served.");
                        }
                        else
                        {
                            Console.WriteLine("No customers in queue.");
                        }
                        break;

                    case "3":
                        if (customerQueue.Count > 0)
                        {
                            Console.WriteLine($"Next customer: {customerQueue.Peek()}");
                        }
                        else
                        {
                            Console.WriteLine("No customers in queue.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
