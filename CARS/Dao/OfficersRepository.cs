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
    public class OfficersRepository
    {
        public List<Officers> officers1 = new List<Officers>();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public OfficersRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void getOfficers()
        {
            cmd.CommandText = "Select * from Officers";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Officers officers = new Officers();
                officers.OfficerID = (int)reader["OfficerID"];
                officers.FirstName = (string)reader["FirstName"];
                officers.LastName = (string)reader["LastName"];
                officers.AgencyID = (int)reader["AgencyID"];
                officers.OfficerRank = (int)reader["AgencyID"];
                officers.BadgeNumber = (int)reader["BadgeNumber"];
                officers.PhoneNumber = (string)reader["mobile_number"];
                officers.Address = (string)reader["officer_address"];
                officers1.Add(officers);

            }
            foreach (Officers of in officers1)
            {
                Console.WriteLine(of.ToString());
            }
            connect.Close();
        }
    }
}
