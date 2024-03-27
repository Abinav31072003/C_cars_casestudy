using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class Reports
    {
        public Reports()
        {
        }

        public int ReportID { get; set; }
        public int IncidentID { get; set; }
        public int ReportingOfficerID { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportDescription { get; set; }
        public string Status { get; set; }

        public Reports(int reportID, int incidentID, int reportingOfficer, string status, DateTime reportDate, string reportDescription)
        {
            ReportID = reportID;
            this.IncidentID = incidentID;
            this.ReportingOfficerID = reportingOfficer;
            Status = status;
            ReportDate = reportDate;
            ReportDescription = reportDescription;
        }

        public override string ToString()
        {
            return $"ReportID::{ReportID}\tIncidentId::{IncidentID}\tOfficerID::{ReportingOfficerID}\tReportStatus::{Status}\tReportDate::{ReportDate}\tReportDescription::{ReportDescription}";
        }
    }
}
