using CARS.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    public class OfficerService
    {
        public OfficerService() { }
        public void OfficerDirectory()
        {
            OfficersRepository officersRepository = new OfficersRepository();
            int choice = 0;
            do
            {

                Console.WriteLine("Officers Details");
                Console.WriteLine($"1: Display\n2. Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        officersRepository.getOfficers();
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
