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
    public class IncidentsRepository
    {
        public List<Incidents> Incidents = new List<Incidents>();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public IncidentsRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public List<Incidents> getIncidents()
        {
            cmd.CommandText = "Select * from Incidents";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Incidents incidents = new Incidents();
                incidents.IncidentID = (int)reader["IncidentID"];
                incidents.IncidentType = (string)reader["IncidentType"];
                incidents.IncidentDate = (DateTime)reader["IncidentDate"];
                incidents.Location = (string)reader["Locations"];
                incidents.Description = (string)reader["Descriptions"];
                incidents.Status = (string)reader["Case_Status"];
                incidents.VictimID = (int)reader["VictimId"];
                incidents.SuspectID = (int)reader["SuspectId"];
                Incidents.Add(incidents);

            }
            connect.Close();
            return Incidents;
        }
    }
}
