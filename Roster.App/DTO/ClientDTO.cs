using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.DTO
{
    public class ClientDTO:BaseDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public string? DOB { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public AddressDTO? Address { get; set; }
        public string? HighlightColor { get; set; }
        public byte RiskCategory { get; set; }
        public string? GenderPreference { get; set; }

        public ClientDTO(string id, string firstName, string lastName, string nickname, string gender, string? dob, string? phone, string? email, string? highlightColor, AddressDTO? address, byte riskCategory, string? genderPreference)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            DOB = dob;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor;
            Address = address;
            RiskCategory = riskCategory;
        }        
    }
}
