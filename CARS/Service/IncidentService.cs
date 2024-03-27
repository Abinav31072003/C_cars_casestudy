using CARS.Dao;
using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    public class IncidentService
    {
        public IncidentService() { }
        public void IncidentDirectory()
        {
            CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
            IncidentsRepository incidents = new IncidentsRepository();
            int choice = 0;
            do
            {
                Console.WriteLine("Incident Details");
                Console.WriteLine($"1: Diplay\n2. Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        List<Incidents> incidents1 = new List<Incidents>();
                        incidents1 = incidents.getIncidents();
                        foreach (Incidents inc in incidents1)
                        {
                            Console.WriteLine(inc);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!!!");
                        break;
                }
            } while (choice != 2);

        }
    }
}
