namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dictionary to store workshop registrations
            Dictionary<string, HashSet<int>> workshopRegistrations = new Dictionary<string, HashSet<int>>();

            while (true)
            {
                Console.WriteLine("\nUniversity Workshop Registration System");
                Console.WriteLine("1. Register Student");
                Console.WriteLine("2. View Workshop Registrations");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Workshop Name: ");
                        string workshop = Console.ReadLine();

                        Console.Write("Enter Student ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int studentID))
                        {
                            Console.WriteLine("Invalid Student ID. Please enter a numeric value.");
                            break;
                        }

                        // If workshop is not in dictionary, add it
                        if (!workshopRegistrations.ContainsKey(workshop))
                        {
                            workshopRegistrations[workshop] = new HashSet<int>();
                        }

                        // Attempt to register the student
                        if (workshopRegistrations[workshop].Add(studentID))
                        {
                            Console.WriteLine($"Student {studentID} successfully registered for {workshop}.");
                        }
                        else
                        {
                            Console.WriteLine($"Student {studentID} is already registered for {workshop}.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nWorkshop Registrations:");
                        foreach (var entry in workshopRegistrations)
                        {
                            Console.WriteLine($"Workshop: {entry.Key}");
                            Console.WriteLine("Registered Students: " + (entry.Value.Count > 0 ? string.Join(", ", entry.Value) : "No students registered."));
                        }
                        break;

                    case "3":
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
