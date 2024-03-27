using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class Victims
    {
        public int VictimID = 1;
        public String FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }


        public Victims()
        {
        }

        public Victims(int victimID, string firstName, string lastName, DateTime dateOfBirth, string gender, string address, string phone_Number)
        {
            VictimID = victimID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone_Number = phone_Number;

        }

        public override string ToString()
        {
            return $"{VictimID}\t{FirstName}\t{LastName}\t{DateOfBirth}\t {Gender}\t{Address}\t       {Phone_Number}";
        }
    }
}
