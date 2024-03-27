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
    public class VictimsRepository
    {
        List<Victims> victims1 = new List<Victims>();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public VictimsRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public List<Victims> getVictims()
        {
            cmd.CommandText = "Select * from Victims";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Victims victims = new Victims();
                victims.VictimID = (int)reader["VictimId"];
                victims.FirstName = (string)reader["FirstName"];
                victims.LastName = (string)reader["LastName"];
                victims.DateOfBirth = (DateTime)reader["DateOfBirth"];
                victims.Gender = (string)reader["Gender"];
                victims.Address = (string)reader["Victim_Address"];
                victims.Phone_Number = (string)reader["mobile_number"];

                victims1.Add(victims);

            }
            connect.Close();
            return victims1;
        }
    }
}
