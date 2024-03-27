using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class Suspects
    {
        public Suspects()
        {
        }

        public int SuspectID = 1;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string address { get; set; }
        public string Phone_number { get; set; }

        public Suspects(int suspectID, string firstName, string lastName, DateTime dateOfBirth, string gender, string address, string phone_number)
        {
            SuspectID = suspectID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            this.address = address;
            Phone_number = phone_number;
        }
        public override string ToString()
        {
            return $"SuspectId::{SuspectID}\tSuspectName::{FirstName + LastName}\tDOB::{DateOfBirth}\tGender::{Gender}\tAddress::{address}\tPhoneNumber::{Phone_number}";
        }
    }
}
