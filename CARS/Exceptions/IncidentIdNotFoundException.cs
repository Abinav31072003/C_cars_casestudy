using CARS.Dao;
using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Exceptions
{
    public class IncidentIdNotFoundException:Exception
    {
        public IncidentIdNotFoundException(string message) : base(message)
        {

        }
        public static void IncidentIdNotFound(int incidentID)
        {
            bool idexist = false;
            IncidentsRepository repository = new IncidentsRepository();
            List<Incidents> excep = new List<Incidents>();
            excep = repository.getIncidents();
            foreach (Incidents incidents in excep)
            {
                if (incidents.IncidentID == incidentID)
                {
                    idexist = true;
                }
            }
            if (!idexist)
            {
                throw new IncidentIdNotFoundException("Incident Id not Found in the List");
            }
        }
    }
}
