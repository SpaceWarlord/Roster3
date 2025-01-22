using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public string? DOB { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
        
        public Address? Address { get; set; }

        public string? HighlightColor { get; set; }

        public ClientDTO(int id, string firstName, string lastName, string nickname, string gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
        }

    }
}
