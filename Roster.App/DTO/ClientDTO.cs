using Roster.App.ViewModels.Data;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
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
        public DateTimeOffset? DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public AddressDTO? Address { get; set; }
        public string? HighlightColor { get; set; }

        public string NDISNumber { get; set; }
        public byte RiskCategory { get; set; }
        public string? GenderPreference { get; set; }

        public ClientDTO(string id, string firstName, string middleName, string lastName, string nickname, string gender, DateTimeOffset? dateOfBirth, string? phone, string? email, 
            string? highlightColor, AddressDTO? address, string ndisNumber, byte riskCategory, string? genderPreference)
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

        public ClientDTO(Client client)
        {
            if (client != null)
            {
                Id = client.Id;
                FirstName = client.FirstName;
                MiddleName = client.MiddleName;
                LastName = client.LastName;
                Nickname = client.Nickname;
                Gender = client.Gender;
                DateOfBirth = client.DateOfBirth;
                Phone = client.Phone;
                Email = client.Email;
                HighlightColor = client.HighlightColor;
                if (client.Address != null)
                {
                    Address = new AddressDTO(client.Address);
                }
                else
                {
                    Address = null;
                }
                NDISNumber = client.NDISNumber;
                RiskCategory = client.RiskCategory;
                GenderPreference = client.GenderPreference;
            }
            else
            {
                Debug.WriteLine("Client was null");
            }
        }

        public ClientDTO(ClientViewModel client)
        {
            if (client!= null)
            {
                Id = client.Id;
                FirstName = client.FirstName;
                MiddleName = client.MiddleName;
                LastName = client.LastName;
                Nickname = client.Nickname;
                Gender = client.Gender;
                DateOfBirth = client.DateOfBirth;
                Phone = client.Phone;
                Email = client.Email;
                HighlightColor = client.HighlightColor;
                if (client.Address != null)
                {
                    Address = new AddressDTO(client.Address);
                }
                else
                {
                    Address = null;
                }
                NDISNumber = client.NDISNumber;
                RiskCategory = client.RiskCategory;
                GenderPreference = client.GenderPreference;
            }
            else
            {
                Debug.WriteLine("ClientViewModel was null");
            }
        }
    }
}
