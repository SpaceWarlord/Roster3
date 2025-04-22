using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class Objective:BaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority PriorityRating { get; set; }

        public string Category { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset CompleteBy { get; set; }
        public bool Completed { get; set; } = false;

        public string? WorkerId { get; set; }
        public string? ClientId { get; set; }

        [ForeignKey("WorkerId")] // for a shadow property to the Address ID FK
        public Worker? Worker { get; set; }

        [ForeignKey("ClientId")] // for a shadow property to the Address ID FK        
        public Client? Client { get; set; }
        public Objective() 
        {
            
        }
    }
}
