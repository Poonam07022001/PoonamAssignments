
using Hackathon_Project.Modals;

namespace Hackathon_Project.Interfaces
{
    interface IPolicyRepository
    {
        //create abstract methods 
        void AddPolicy(Policy policy);
        void ViewAllPolicies();
        Policy SearchPolicy(int id);
        void UpadatePolicy(int id, string name, PolicyType type, DateTime start, DateTime end);
        void DeletePolicy(int id);

        void ViewActivePolicy();
    }
}
