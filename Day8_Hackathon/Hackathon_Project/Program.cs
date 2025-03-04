using Hackathon_Project.Exceptions;
using Hackathon_Project.Interfaces;
using Hackathon_Project.Modals;
using Hackathon_Project.Repository;

namespace Hackathon_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPolicyRepository policyRepo = new PolicyRepository();
            while (true)
            {
                Console.WriteLine("\nInsurance Policy Management System");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. View All Policies");
                Console.WriteLine("3. Search Policy by ID");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("6. View Active Policies");
                Console.WriteLine("7. Exit");
                Console.Write("Enter choice: ");

                //Ensures valid input
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input, try again.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Policy ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Policy Holder Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Policy Type (Life, Health, Vehicle, Property): ");
                            PolicyType type = Enum.Parse<PolicyType>(Console.ReadLine(), true);
                            Console.Write("Enter Start Date (yyyy-MM-dd): ");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter End Date (yyyy-MM-dd): ");
                            DateTime endDate = DateTime.Parse(Console.ReadLine());
                            policyRepo.AddPolicy(new Policy(id, name, type, startDate, endDate));
                            break;

                        case 2:
                            policyRepo.ViewAllPolicies();
                            break;

                        case 3:
                            Console.Write("Enter Policy ID: ");
                            Console.WriteLine(policyRepo.SearchPolicy(int.Parse(Console.ReadLine())));
                            break;

                        case 4:
                            Console.Write("Enter Policy ID: ");
                            int updateId = int.Parse(Console.ReadLine());
                            Console.Write("Enter New Name: ");
                            string newName = Console.ReadLine();
                            Console.Write("Enter New Type: ");
                            PolicyType newType = Enum.Parse<PolicyType>(Console.ReadLine(), true);
                            Console.Write("Enter New Start Date: ");
                            DateTime newStartDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter New End Date: ");
                            DateTime newEndDate = DateTime.Parse(Console.ReadLine());
                            policyRepo.UpadatePolicy(updateId, newName, newType, newStartDate, newEndDate);
                            break;

                        case 5:
                            Console.Write("Enter Policy ID to Delete: ");
                            policyRepo.DeletePolicy(int.Parse(Console.ReadLine()));
                            break;

                        case 6:
                            policyRepo.ViewActivePolicy();
                            break;

                        case 7:
                            return;

                        default:
                            Console.WriteLine("Invalid choice, try again.");
                            break;
                    }
                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
