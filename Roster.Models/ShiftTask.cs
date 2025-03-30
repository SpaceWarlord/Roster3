using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class ShiftTask
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        public byte Priority { get; set; }

        public ShiftTask(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
