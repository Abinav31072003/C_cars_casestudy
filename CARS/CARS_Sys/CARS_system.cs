using CARS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.CARS_Sys
{
    internal class CARS_system
    {
        public CARS_system() { }
        public static void carsmenu()
        {
            int option = 0;
            ServiceImplementationClass serviceImplementationClass = new ServiceImplementationClass();
            do
            {
                Console.WriteLine("Crime Analysis Reporting System");
                Console.WriteLine("1. Incidents Details\n2. Evidences Details\n3. Law Enforcement Agencies Details\n4. Cases Details\n5. Officers Details\n6. Suspects Details\n7. Victims Details\n8. Crime Analysis and Reporting System\n9. Exit\n");
                Console.WriteLine("Enter the operation you want to perform::");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Incidents Details");
                        IncidentService incidentService = new IncidentService();
                        incidentService.IncidentDirectory();
                        break;

                    case 2:
                        Console.WriteLine("Evidences Details");
                        EvidenceService evidenceService = new EvidenceService();
                        evidenceService.EvidenceDirectory();
                        break;

                    case 3:
                        Console.WriteLine("Law Enforcement Agencies Details");
                        LawEnforcementServicecs lawEnforcementServicecs = new LawEnforcementServicecs();
                        lawEnforcementServicecs.LawEnforcementDirectory();
                        break;

                    case 4:
                        Console.WriteLine("Cases Details");
                        CasesService casesService = new CasesService();
                        casesService.CaseDirectory();
                        break;

                    case 5:
                        Console.WriteLine("Officers Details");
                        OfficerService officerService = new OfficerService();
                        officerService.OfficerDirectory();
                        break;

                    case 6:
                        Console.WriteLine("Suspects Details");
                        SuspectsService service = new SuspectsService();
                        service.SuspectDirectory();
                        break;

                    case 7:
                        Console.WriteLine("Victims Details");
                        VictimService victimService = new VictimService();
                        victimService.VictimDirectory();
                        break;

                    case 8:
                        Console.WriteLine("Crime Analysis and Reporting System");
                        serviceImplementationClass.run();
                        break;

                    case 9:
                        Console.WriteLine("Exiting..");
                        break;

                    default: Console.WriteLine("Invalid Option"); break;
                }

            } while (option != 9);


        }
    }
}
