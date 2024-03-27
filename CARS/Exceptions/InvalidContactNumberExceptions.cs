using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Exceptions
{
    public class InvalidContactNumberExceptions:Exception
    {
        public InvalidContactNumberExceptions(string message) : base(message) { }
        public static void InvalidContactNumber(string ph_num)
        {
            if (ph_num.Length > 10)
            {
                throw new InvalidContactNumberExceptions("Enter the valid PhoneNumber");
            }
        }
    }
}
