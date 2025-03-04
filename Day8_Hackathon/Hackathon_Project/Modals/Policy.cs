
using System.Runtime.InteropServices;

namespace Hackathon_Project.Modals
{
    // Enum for Policy Types
    public enum PolicyType
    {
        Life,
        Health,
        Vehicle,
        Property
    }

    //Represents an insurance policy
    public class Policy
    {
        public int PolicyID { get; set; }
        public PolicyType Type { get; set; }
        public string PolicyHolderName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        //Create Constructor
        public Policy(int id, string name, PolicyType type, DateTime start, DateTime end)
        {
            PolicyID = id;
            PolicyHolderName = name;
            Type = type;
            StartDate = start;
            EndDate = end;
        }

        //Checks if a policy is currently active
        public bool IsActive()
        {
            return DateTime.Now >= StartDate && DateTime.Now <= EndDate;
        }

        //display policy details
        public override string ToString()
        {
            return $"ID::{PolicyID} Name::{PolicyHolderName} Type::{Type} Start::{StartDate.ToShortDateString()} End::{EndDate.ToShortDateString()} Active::{IsActive()}";
        }
    }
}
