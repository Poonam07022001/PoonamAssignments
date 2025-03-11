using InsuranceWithDatabase.Interface;
using InsuranceWithDatabase.Modals;
using InsuranceWithDatabase.Utility;
using System.Data.SqlClient;
using System.Data;
using InsuranceWithDatabase.Exceptions;

namespace InsuranceWithDatabase.Repository
{
    class PolicyRepository : IPolicyRepository
    {
        SqlCommand cmd = null;
        string connstring;

        public PolicyRepository()
        {
  
            cmd = new SqlCommand();
            connstring = DbConnUtil.GetConnectionString();
        }

        public int AddPolicy(Policy policy)
        {
            Console.Write("Enter Policy Holder Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Policy Type (Life, Health, Vehicle, Property): ");
            int type = int.Parse(Console.ReadLine());
            Console.Write("Enter Start Date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter End Date (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            //policyRepo.AddPolicy(new Policy(name, type, startDate, endDate));
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.CommandText = "Insert into Policy values(@PolicyHolderName,@PolicyType,@StartDate,@EndDate)";
                //cmd.Parameters.AddWithValue("@PolicyID", policy.PolicyID);
                cmd.Parameters.AddWithValue("@PolicyHolderName",name);
                cmd.Parameters.AddWithValue("@PolicyType", type);         
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate",endDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();
                

            }
        }

        public int DeletePolicy(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.CommandText = "Delete from Policy where PolicyID=@PolicyID";
                cmd.Parameters.AddWithValue("@PolicyID", id);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public Policy SearchPolicy(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Policy WHERE PolicyID = @PolicyID", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@PolicyID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Read single record
                        {
                            return new Policy
                            {
                                PolicyID = reader.GetInt32(reader.GetOrdinal("PolicyID")), // Assign separately
                                PolicyHolderName = reader.GetString(reader.GetOrdinal("PolicyHolderName")),
                                PolicyType = reader.GetInt32(reader.GetOrdinal("PolicyType")),
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"))
                            };
                        }
                    }
                }
            }

            return null; 
        }

        public int UpadatePolicy(int id)
        {
            int rowsAffected = 0;

            Console.Write("Enter New Policy Holder Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter New Policy Type (0=Life, 1=Health, 2=Vehicle, 3=Property): ");
            int newType = int.Parse(Console.ReadLine());

            Console.Write("Enter New Start Date (yyyy-MM-dd): ");
            DateTime newStartDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter New End Date (yyyy-MM-dd): ");
            DateTime newEndDate = DateTime.Parse(Console.ReadLine());
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand(@"UPDATE Policy 
                                                 SET PolicyHolderName = @PolicyHolderName, 
                                                     PolicyType = @PolicyType, 
                                                     StartDate = @StartDate, 
                                                     EndDate = @EndDate 
                                                 WHERE PolicyID = @PolicyID", sqlConnection))
                { 
                    
                    cmd.Parameters.AddWithValue("@PolicyId", id);
                    cmd.Parameters.AddWithValue("@PolicyHolderName", newName);
                    cmd.Parameters.AddWithValue("@PolicyType", newType);
                    cmd.Parameters.AddWithValue("@StartDate", newStartDate);
                    cmd.Parameters.AddWithValue("@EndDate", newEndDate);

                     rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new PolicyNotFoundException($"Policy with ID {id} not found.");
                    }
                    else{
                        Console.WriteLine("Policy Updated");
                    }
                }
                return rowsAffected;
            }
            
        }


        public List<Policy> ViewAllPolicies()
        {
            List<Policy> policies = new List<Policy>();

            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.CommandText = "Select * from Policy";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyID = reader.GetInt32("PolicyId");
                    policy.PolicyHolderName = reader.GetString("PolicyHolderName");
                    policy.PolicyType = reader.GetInt32("PolicyId"); ;
                    policy.StartDate = reader.GetDateTime("StartDate");
                    policy.EndDate = reader.GetDateTime("EndDate");

                    policies.Add(policy);

                }

            }
            return policies;
        }
    }
}
