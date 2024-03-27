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
    public class CasesRepository
    {
        public List<Cases> Cases = new List<Cases>();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public CasesRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public List<Cases> getCases()
        {
            cmd.CommandText = "Select * from Cases";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cases cases = new Cases();
                cases.CaseId = (int)reader["caseID"];
                cases.caseDescription = (string)reader["CaseDescription"];
                cases.caseStatus = (string)reader["caseStatus"];
                cases.incidentId = (int)reader["incidentId"];

                Cases.Add(cases);

            }

            connect.Close();
            return Cases;
        }
    }
}
