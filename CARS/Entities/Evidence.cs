using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class Evidence
    {
        public Evidence()
        {
        }

        public int EvidenceID { get; set; } = 1;
        public string Description { get; set; }
        public string Location_Found { get; set; }
        public Incidents Incidents { get; set; }
        public int IncidentID { get; set; }

        public Evidence(int evidenceID, string description, string location_Found, Incidents incidents)
        {
            this.EvidenceID = evidenceID;
            this.Description = description;
            this.Location_Found = location_Found;
            this.Incidents = incidents;
        }

        public Evidence(int evidenceID, string description, string location_Found, int incidentID)
        {
            EvidenceID = evidenceID;
            Description = description;
            Location_Found = location_Found;
            IncidentID = incidentID;
        }

        public override string ToString()
        {
            return $"{EvidenceID}\t{Description}\t{Location_Found}\t{Incidents}\t";
        }
    }
}
