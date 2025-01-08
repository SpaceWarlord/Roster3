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
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Nickname { get; set; }
        public required string Gender { get; set; }
        public string? DOB { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
        
        public Address? Address { get; set; }

        public string? HighlightColor { get; set; }

    }
}
