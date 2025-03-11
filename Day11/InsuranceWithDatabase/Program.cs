using InsuranceWithDatabase.Exceptions;
using InsuranceWithDatabase.Interface;
using InsuranceWithDatabase.Modals;
using InsuranceWithDatabase.Repository;

namespace InsuranceWithDatabase
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
                            policyRepo.AddPolicy(new Policy( ));
                            Console.Write("Added Policy");
                            break;

                        case 2:
                            List<Policy> policies = policyRepo.ViewAllPolicies();

                            if (policies.Count == 0)
                            {
                                Console.WriteLine("No policies found.");
                            }
                            else
                            {
                                Console.WriteLine("\nList of Policies:");
                                foreach (var policy in policies)
                                {
                                    Console.WriteLine(policy.ToString());
                                }
                            }
                            break;

                        case 3:
                            Console.Write("Enter Policy ID: ");
                            Console.WriteLine(policyRepo.SearchPolicy(int.Parse(Console.ReadLine())));
                            break;


                        case 4: // Update Policy
                            Console.Write("Enter Policy ID to Update: ");
                            int updateId = int.Parse(Console.ReadLine());
                            policyRepo.UpadatePolicy(updateId);
                            Console.WriteLine("Policy updated successfully.");
                            break;

                        case 5:
                            Console.Write("Enter Policy ID to Delete: ");
                            policyRepo.DeletePolicy(int.Parse(Console.ReadLine()));
                            Console.Write("Deleted Succesfully");
                            break;

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