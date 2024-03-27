using CARS.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    public class EvidenceService
    {
        public EvidenceService() { }
        public void EvidenceDirectory()
        {
            CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
            EvidencesRepository evidencesRepository = new EvidencesRepository();
            int choice = 0;
            do
            {
                Console.WriteLine("Evidence Details");
                Console.WriteLine($"1: Display\n2. Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        evidencesRepository.getEvidences();
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
