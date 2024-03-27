using CARS.Entities;
using CARS.PropertyUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CARS.Dao
{
    public class LawEnforcementAgenciesRepository
    {
        public List<LawEnforcementAgencies> LawEnforcementAgencies = new List<LawEnforcementAgencies>();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public LawEnforcementAgenciesRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void getAgencies()
        {
            cmd.CommandText = "Select * from Law_Enforcement_Agencies";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LawEnforcementAgencies lawEnforcementAgencies = new LawEnforcementAgencies();
                lawEnforcementAgencies.AgencyID = (int)reader["AgencyID"];
                lawEnforcementAgencies.AgencyName = (string)reader["AgencyName"];
                lawEnforcementAgencies.Jurisdiction = (string)reader["Jurisdiction"];
                lawEnforcementAgencies.AgencyID = (int)reader["AgencyID"];
                lawEnforcementAgencies.Phone_Number = (string)reader["Mobile_number"];
                lawEnforcementAgencies.Address = (string)reader["Agencies_address"];
                LawEnforcementAgencies.Add(lawEnforcementAgencies);

            }
            foreach (var Law in LawEnforcementAgencies)
            {
                Console.WriteLine(Law.ToString());
            }
            connect.Close();
        }
    }
}
