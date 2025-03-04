
using Hackathon_Project.Exceptions;
using Hackathon_Project.Interfaces;
using Hackathon_Project.Modals;

namespace Hackathon_Project.Repository
{
    class PolicyRepository : IPolicyRepository
    {
        // List to store policy objects
        List<Policy> policies = new List<Policy>();

        public void AddPolicy(Policy policy)
        {
            if (policies.Any(p => p.PolicyID == policy.PolicyID))
            {
                Console.WriteLine("Policy ID already exists!");
                return;
            }
            policies.Add(policy);
            Console.WriteLine("Policy Details added succesfully!");
        }

        public void ViewAllPolicies()
        {
            if (policies.Count == 0)
            {
                Console.WriteLine("No Policies found");
            }
            policies.ForEach(p => Console.WriteLine(p));
        }

        public Policy SearchPolicy(int id)
        {
            var policy = policies.FirstOrDefault(p => p.PolicyID == id);
            if (policy == null)
                throw new PolicyNotFoundException("Policy not found.");
            return policy;
        }

        public void UpadatePolicy(int id, string name, PolicyType type, DateTime start, DateTime end)
        {
            var policy = SearchPolicy(id);
            policy.PolicyHolderName = name;
            policy.Type = type;
            policy.StartDate = start;
            policy.EndDate = end;
            Console.WriteLine("Policy updated successfully.");
        }

        public void DeletePolicy(int id)
        {
            var policy = SearchPolicy(id);
            policies.Remove(policy);
            Console.WriteLine("Policy deleted successfully.");
            // Console.WriteLine(policies);
        }


        public void ViewActivePolicy()
        {
            var activePolicies = policies.Where(p => p.IsActive()).ToList();
            if (activePolicies.Count == 0)
            {
                Console.WriteLine("No active policies found.");
                return;
            }
            activePolicies.ForEach(p => Console.WriteLine(p));
        }

    }
}
