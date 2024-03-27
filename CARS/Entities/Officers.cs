using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class Officers
    {
        public Officers()
        {
        }

        public int OfficerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BadgeNumber { get; set; }
        public string Address { get; set; }
        public int OfficerRank { get; set; }
        public string PhoneNumber { get; set; }
        public int AgencyID { get; set; }

        public Officers(int officerID, string firstName, string lastName, int badgeNumber, string address, string phoneNumber, int agencyID)
        {
            OfficerID = officerID;
            FirstName = firstName;
            LastName = lastName;
            BadgeNumber = badgeNumber;
            Address = address;
            PhoneNumber = phoneNumber;
            AgencyID = agencyID;
        }

        public override string ToString()
        {
            return $"{OfficerID}\t{FirstName}\t{LastName}\t{BadgeNumber}\t {Address}\t{PhoneNumber}\t{AgencyID}";
        }
    }
}
