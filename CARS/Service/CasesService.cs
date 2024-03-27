using CARS.Dao;
using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    public class CasesService
    {
        public CasesService() { }
        public void CaseDirectory()
        {
            CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
            int choice = 0;
            do
            {
                Console.WriteLine("Case Details");
                Console.WriteLine($"1: Display\n2. Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        List<Cases> cases2 = new List<Cases>();
                        Console.WriteLine("Display");
                        cases2 = crimeAnalysisServiceImpl.getAllCases();
                        foreach (Cases c in cases2)
                        {
                            Console.WriteLine(c);
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
