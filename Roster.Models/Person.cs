using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace Roster.Models
{
    [Index(nameof(Nickname), IsUnique = true)]
    //public class Person: IEquatable<Person>
    public class Person
    {

        //bug with using required. Don't use for now https://github.com/microsoft/microsoft-ui-xaml/issues/8723
        public string Id { get; set; }
        
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? Nickname { get; set; }

        [NotMapped]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }


        public string? Gender { get; set; }
        
        public string? DateOfBirth { get; set; }
        
        public string? Phone { get; set; }
        
        public string? Email { get; set; }        

        [ForeignKey("AddressId")] // for a shadow property to the Address ID FK
        public virtual Address? Address { get; set; }

        public string? HighlightColor { get; set; }

        public string? Avatar { get; set; }

        /// <summary>
        /// Returns the person's full name.
        /// </summary>
        public override string ToString() => $"{FirstName} {LastName}";

        /*
        public bool Equals(Person other) =>
            FirstName == other.FirstName &&
            LastName == other.LastName &&
            Nickname == other.Nickname &&
            Gender == other.Gender &&
            DOB == other.DOB &&            
            Phone == other.Phone &&
            Email == other.Email &&
            Address == other.Address;
        
        

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }
        */

        public Person()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Person(string id)
        {
            Id = id;
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}