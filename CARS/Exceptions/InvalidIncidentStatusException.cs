using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Exceptions
{
    public class InvalidIncidentStatusException:Exception
    {
        public InvalidIncidentStatusException(string message) : base(message)
        {
        }
        public static void InvalidIncidentStatus(string status)
        {
            bool suitable = false;
            if (status == "open" || status == "closed" || status == "reviewed")
            {
                suitable = true;
            }
            if (!suitable)
            {
                throw new InvalidIncidentStatusException("Invalid Status!!!!");
            }
        }
    }
}
