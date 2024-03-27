using CARS.Entities;
using CARS.Exceptions;
using CARS.PropertyUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CARS.Dao
{
    public class CrimeAnalysisServiceImpl:ICrimeAnalysisService
    {
        Incidents Incidents = new Incidents();
        Suspects suspects = new Suspects();
        Victims Victims = new Victims();

        IncidentsRepository IncidentsRepository = new IncidentsRepository();
        ReportsRepository ReportsRepository = new ReportsRepository();
        CasesRepository casesRepository = new CasesRepository();

        SqlConnection connect = null;
        SqlCommand cmd = null;
        public CrimeAnalysisServiceImpl()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public bool CreateIncident()
        {
            try
            {
                Console.WriteLine("Enter the IncidentType::");
                string IncidentType = Console.ReadLine();
                Console.WriteLine("Enter the IncidentDate::");
                string IncidentDate = Console.ReadLine();
                Console.WriteLine("Enter the Location of the Incident::");
                string Location = Console.ReadLine();
                Console.WriteLine("Description::");
                string Description = Console.ReadLine();
                Console.WriteLine("Status of the Incident::");
                string status = Console.ReadLine();
                Console.WriteLine("Enter victim id::");
                int victimid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter suspect id::");
                int suspectid = int.Parse(Console.ReadLine());
                cmd.CommandText = "Insert into Incidents values(@type,@date,@location,@description,@caseStatus,@victimID,@suspectID)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@type", IncidentType);
                cmd.Parameters.AddWithValue("@date", IncidentDate);
                cmd.Parameters.AddWithValue("@location", Location);
                cmd.Parameters.AddWithValue("@description", Description);
                cmd.Parameters.AddWithValue("@caseStatus", status);
                cmd.Parameters.AddWithValue("@victimID", victimid);
                cmd.Parameters.AddWithValue("@suspectID", suspectid);

                cmd.Connection = connect;
                connect.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Incident created!!!");

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            connect.Close();

            return true;
        }
        public bool updateIncidentStatus(int incidentId)
        {
            try
            {
                Console.WriteLine("Enter the updatedCase Status");
                string casestatus = Console.ReadLine();
                InvalidIncidentStatusException.InvalidIncidentStatus(casestatus);
                cmd.CommandText = "update Incidents set Case_Status=@caseStatus where IncidentID=@incidentid";
                cmd.Connection = connect;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@caseStatus", casestatus);
                cmd.Parameters.AddWithValue("@incidentid", incidentId);
                connect.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Status updated!!!!");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            connect.Close();

            return true;

        }
        public List<Incidents> getIncidentsInDateRange(DateTime StartDate, DateTime EndDate)
        {
            List<Incidents> incidents1 = new List<Incidents>();
            cmd.CommandText = "select * from Incidents where IncidentDate between @startdate  and @enddate";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@startdate", StartDate);
            cmd.Parameters.AddWithValue("@enddate", EndDate);
            connect.Open();
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
                incidents1.Add(incidents);

            }
            connect.Close();
            return incidents1;
        }

        public List<Incidents> searchIncidents(object criteria)
        {
            List<Incidents> incidents2 = new List<Incidents>();
            cmd.CommandText = "select * from Incidents where IncidentType=@criteria";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@criteria", criteria);
            connect.Open();
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
                incidents2.Add(incidents);

            }
            connect.Close();
            return incidents2;
        }
        public Reports generateIncidentReport(object incidents)
        {
            Console.WriteLine();
            Reports reports = new Reports();
            cmd.CommandText = "Select * from Reports where IncidentID=@incidentid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@incidentid", incidents);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                reports.ReportID = (int)reader["ReportID"];
                reports.ReportingOfficerID = (int)reader["ReportingOfficerID"];
                reports.IncidentID = (int)reader["IncidentID"];
                reports.Status = (string)reader["evidence_status"];
                reports.ReportDate = (DateTime)reader["ReportDate"];
                reports.ReportDescription = (string)reader["ReportDetails"];


            }
            connect.Close();
            return reports;
        }
        public bool createCase()
        {
            Cases cases = new Cases();
            int CaseId = cases.CaseId++;
            Console.WriteLine("Enter the CaseStatus::");
            string case_Status = Console.ReadLine();
            Console.WriteLine("Enter the Description::");
            string caseDescription = Console.ReadLine();
            Console.WriteLine("Enter the incidentid");
            int incidentID = int.Parse(Console.ReadLine());
            cmd.CommandText = "insert into Cases values(@des,@status,@id)";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@des", caseDescription);
            cmd.Parameters.AddWithValue("@status", case_Status);
            cmd.Parameters.AddWithValue("@id", incidentID);
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            IncidentsRepository incidentsRepository = new IncidentsRepository();
            List<Incidents> Caseincident = new List<Incidents>();
            Caseincident = incidentsRepository.getIncidents();
            Console.WriteLine("Case Details Created");
            return true;
        }
        public Cases getCaseDetails(int caseId)
        {


            cmd.CommandText = "Select * from Cases where caseID=@caseid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@caseid", caseId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            Cases case1 = new Cases();

            while (reader.Read())
            {
                case1.CaseId = (int)reader["CaseId"];
                case1.caseDescription = (string)reader["CaseDescription"];
                case1.caseStatus = (string)reader["caseStatus"];
                case1.incidentId = (int)reader["incidentId"];

            }
            connect.Close();
            return case1;

        }
        public bool updateCaseStatus(int caseid)
        {
            try
            {

                Console.WriteLine("Enter the CaseStatustoUpdate::");
                string case_Status = Console.ReadLine();
                InvalidIncidentStatusException.InvalidIncidentStatus(case_Status);
                cmd.CommandText = "update Cases set caseStatus=@casestatus  where caseID=@caseid";
                cmd.Connection = connect;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@casestatus", case_Status);
                cmd.Parameters.AddWithValue("@caseid", caseid);
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                Console.WriteLine("**Status Updated**");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return true;
        }

        public bool updateCaseDetails(Cases cases)
        {
            cmd.CommandText = "update Cases set caseStatus=@casestatus,CaseDescription=@des,incidentId=@incid  where caseID=@caseid";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@casestatus", cases.caseStatus);
            cmd.Parameters.AddWithValue("@caseid", cases.CaseId);
            cmd.Parameters.AddWithValue("des", cases.caseDescription);
            cmd.Parameters.AddWithValue("incid", cases.incidentId);
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            Console.WriteLine("Case Details Updated!!!!!");
            return true;
        }
        public List<Cases> getAllCases()
        {
            List<Cases> cases = new List<Cases>();
            CasesRepository casesRepository = new CasesRepository();
            cases = casesRepository.getCases();
            return cases;
        }

        public bool testcreateIncident(Incidents incident)
        {
            cmd.CommandText = "Insert into Incidents values(@type,@date,@location,@description,@caseStatus,@victimID,@suspectID)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@type", incident.IncidentType);
            cmd.Parameters.AddWithValue("@date", incident.IncidentDate);
            cmd.Parameters.AddWithValue("@location", incident.Location);
            cmd.Parameters.AddWithValue("@description", incident.Description);
            cmd.Parameters.AddWithValue("@caseStatus", incident.Status);
            cmd.Parameters.AddWithValue("@victimID", incident.VictimID);
            cmd.Parameters.AddWithValue("@suspectID", incident.SuspectID);

            cmd.Connection = connect;
            connect.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool testupdateIncident(int id, String status)
        {
            cmd.CommandText = "update Incidents set Case_Status=@caseStatus where IncidentID=@incidentid";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@caseStatus", status);
            cmd.Parameters.AddWithValue("@incidentid", id);
            connect.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
