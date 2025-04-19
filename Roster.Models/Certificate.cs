using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class Certificate:BaseModel
    {
        public string Id { get; set; }        
        public string Name { get; set; }            
        public string? Description { get; set; }
        public int? Duration { get; set; }
        public bool Infinite { get; set; } = false;
        public bool Required { get; set; } = true;

        public Certificate()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
