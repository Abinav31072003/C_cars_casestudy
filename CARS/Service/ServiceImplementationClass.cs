using CARS.Dao;
using CARS.Entities;
using CARS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    public class ServiceImplementationClass
    {
        public ServiceImplementationClass() { }
        public void run()
        {
            int option = 0;
            CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
            do
            {
                Console.WriteLine("Crime Analysis Management System");
                Console.WriteLine("1. Create Incidents\n2. UpdateIncidentStatus\n3. GetIncidentDateRange\n4. SearchIncidents\n5. GenerateIncidentReport\n6. CreateCases\n7. UpdateCaseDetails\n8. GetCaseDetails\n9. GetListofCases\n10. Exit\n");
                Console.WriteLine("Enter the operation you want to perform::");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Create Incidents");
                        crimeAnalysisServiceImpl.CreateIncident();
                        break;

                    case 2:
                        Console.WriteLine("UpdateIncidentStatus");
                        try
                        {
                            Console.WriteLine("Enter the Incident id to update::");
                            int incident_id = int.Parse(Console.ReadLine());
                            IncidentIdNotFoundException.IncidentIdNotFound(incident_id);
                            crimeAnalysisServiceImpl.updateIncidentStatus(incident_id);

                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 3:
                        List<Incidents> incidents1 = new List<Incidents>();
                        Console.WriteLine("GetIncidentDateRange");
                        Console.WriteLine("Enter the startDate::");
                        string startdate = Console.ReadLine();
                        Console.WriteLine("Enter the Enddate::");
                        string enddate = Console.ReadLine();
                        incidents1 = crimeAnalysisServiceImpl.getIncidentsInDateRange(DateTime.Parse(startdate), DateTime.Parse(enddate));
                        foreach (var incidents in incidents1)
                        {
                            Console.WriteLine(incidents);
                            Console.WriteLine();
                        }
                        break;

                    case 4:
                        List<Incidents> incidents_Impl = new List<Incidents>();
                        Console.WriteLine("SearchIncidents");
                        Console.WriteLine("Enter the incidentType::");
                        string criteria = Console.ReadLine();
                        incidents_Impl = crimeAnalysisServiceImpl.searchIncidents(criteria);
                        foreach (Incidents incidents in incidents_Impl)
                        {
                            Console.WriteLine(incidents.ToString());
                            Console.WriteLine();
                        }
                        break;

                    case 5:
                        Console.WriteLine("GenerateIncidentReport");
                        Reports reports_impl = new Reports();
                        try
                        {
                            Console.WriteLine("Enter the incidents::");
                            int id = int.Parse(Console.ReadLine());
                            IncidentIdNotFoundException.IncidentIdNotFound((id));
                            reports_impl = crimeAnalysisServiceImpl.generateIncidentReport(id);
                            Console.WriteLine(reports_impl.ToString());
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 6:
                        Console.WriteLine("CreateCases");
                        crimeAnalysisServiceImpl.createCase();
                        break;

                    case 7:
                        Console.WriteLine("UpdateCaseDetails");
                        Cases cases = new Cases();
                        Console.WriteLine("Enter the caseId to update");
                        int caseid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the casestatus to update");
                        string caseStatus = Console.ReadLine();
                        Console.WriteLine("Enter the case description to update");
                        string casedescrip = Console.ReadLine();
                        Console.WriteLine("Enter the IncidentId to update");
                        int incidentid = int.Parse(Console.ReadLine());
                        cases = new Cases(caseid, casedescrip, caseStatus, incidentid);
                        crimeAnalysisServiceImpl.updateCaseDetails(cases);
                        break;

                    case 8:
                        Cases cases1 = new Cases();
                        Console.WriteLine("GetCaseDetails");
                        Console.WriteLine("Enter the caseID to get");
                        int caseId = int.Parse(Console.ReadLine());
                        cases1 = crimeAnalysisServiceImpl.getCaseDetails(caseId);
                        Console.WriteLine(cases1.ToString());
                        IncidentsRepository incidentsRepository = new IncidentsRepository();
                        List<Incidents> Caseincident = new List<Incidents>();
                        Caseincident = incidentsRepository.getIncidents();
                        foreach (Incidents incidents in Caseincident)
                        {

                            if (cases1.incidentId == incidents.IncidentID)
                            {

                                Console.WriteLine(incidents);
                            }
                        }
                        break;

                    case 9:
                        List<Cases> cases2 = new List<Cases>();
                        Console.WriteLine("GetListofCases");
                        cases2 = crimeAnalysisServiceImpl.getAllCases();
                        foreach (Cases c in cases2)
                        {
                            Console.WriteLine(c);
                        }
                        break;


                    case 10:
                        Console.WriteLine("Exiting..");
                        break;

                    default: Console.WriteLine("Invalid Option"); break;
                }

            } while (option != 10);


        }
    }
}
