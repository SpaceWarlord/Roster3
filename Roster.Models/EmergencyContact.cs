using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class EmergencyContact : Person
    {        
        public Person ContactFor;

        public EmergencyContact(string firstName, string lastName, string nickname, string gender, Person contactFor) : base(firstName, lastName, nickname, gender)
        {
            ContactFor = contactFor;
        }

    }
}