using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class Incidents
    {
        public Incidents()
        {
        }

        public int IncidentID = 1;
        public String IncidentType { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }
        public int VictimID { get; set; }
        public int SuspectID { get; set; }
        public Victims Victims { get; set; }
        public Suspects Suspects { get; set; }

        public Incidents(int incidentID, string incidentType, DateTime incidentDate, string location, string description, string status, int victimID, int suspectID)
        {
            IncidentID = incidentID;
            IncidentType = incidentType;
            IncidentDate = incidentDate;
            Location = location;
            Description = description;
            Status = status;
            VictimID = victimID;
            SuspectID = suspectID;
        }

        public Incidents(int incidentID, string incidentType, DateTime incidentDate, string location, string description, string status, Victims victimID, Suspects suspectId)
        {
            IncidentID = incidentID;
            IncidentType = incidentType;
            IncidentDate = incidentDate;
            Location = location;
            Description = description;
            Status = status;
            Victims = victimID;
            Suspects = suspectId;
        }
        public override string ToString()
        {
            return $"IncidentID::{IncidentID}\tIncidentType::{IncidentType}\tIncidentDate::{IncidentDate}\tLacoation::{Location}\tDescription::{Description}\tStatus::{Status}\t";
        }
    }
}
