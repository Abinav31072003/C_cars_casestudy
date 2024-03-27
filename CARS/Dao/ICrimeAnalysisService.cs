using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Dao
{
    public interface ICrimeAnalysisService
    {
        public bool CreateIncident();
        public bool updateIncidentStatus(int incidentID);
        public List<Incidents> getIncidentsInDateRange(DateTime StartDate, DateTime EndDate);
        public List<Incidents> searchIncidents(object criteria);
        public Reports generateIncidentReport(object incidents);
        public bool createCase();
        public Cases getCaseDetails(int caseId);
        public bool updateCaseDetails(Cases cases);
        public List<Cases> getAllCases();
    }
}
