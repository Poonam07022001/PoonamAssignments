
using InsuranceWithDatabase.Modals;

namespace InsuranceWithDatabase.Interface
{
    interface IPolicyRepository
    {
        int AddPolicy(Policy policy);
        List<Policy> ViewAllPolicies();
        Policy SearchPolicy(int id);
        int UpadatePolicy(int id);
        int DeletePolicy(int id);

        
    }
}
