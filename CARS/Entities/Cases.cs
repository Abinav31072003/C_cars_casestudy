using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class Cases
    {
        public int CaseId { get; set; } = 1;
        public string caseDescription { get; set; }
        public string caseStatus { get; set; }
        public int incidentId { get; set; }
        public List<Incidents> incidents { get; set; }
        public Cases()
        {
        }

        public Cases(int caseId)
        {
            CaseId = caseId;
        }

        public Cases(int caseId, string caseDescription, string caseStatus, int incidentId)
        {
            this.CaseId = caseId;
            this.caseDescription = caseDescription;
            this.caseStatus = caseStatus;
            this.incidentId = incidentId;
        }

        public Cases(int caseId, string caseDescription, List<Incidents> incidents, string caseStatus)
        {
            CaseId = caseId;
            this.caseDescription = caseDescription;
            this.incidents = incidents;
            this.caseStatus = caseStatus;
        }
        public override string ToString()
        {
            return $"{CaseId}\t{caseDescription}\t{incidentId}\t{caseStatus}";
        }
    }
}
