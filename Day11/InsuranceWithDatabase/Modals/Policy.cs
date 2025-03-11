
namespace InsuranceWithDatabase.Modals
{
    // Enum for Policy Types
    public enum PolicyType
    {
        Life,
        Health,
        Vehicle,
        Property
    }
    class Policy
    {
        public int PolicyID { get; set; }

        public int PolicyType  { get; set; }
        public string PolicyHolderName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Policy()
        {
        }

        public override string ToString()
        {
            return $" Name::{PolicyHolderName} Type::{PolicyType} Start::{StartDate.ToShortDateString()} End::{EndDate.ToShortDateString()}";
        }
    }
}
