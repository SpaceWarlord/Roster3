﻿using Roster.Models;
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

        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public AddressDTO? Address { get; set; }
        public string? HighlightColor { get; set; }

        public string NDISNumber { get; set; }
        public byte RiskCategory { get; set; }
        public string? GenderPreference { get; set; }

        public ClientDTO(string id, string firstName, string middleName, string lastName, string nickname, string gender, string? dateOfBirth, string? phone, string? email, string? highlightColor, AddressDTO? address, string ndisNumber, byte riskCategory, string? genderPreference)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor;
            Address = address;
            NDISNumber = ndisNumber;
            RiskCategory = riskCategory;
            GenderPreference = genderPreference;
        }        
    }
}
