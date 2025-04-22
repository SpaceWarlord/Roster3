using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class Roster
    {
        public int Id {  get; set; }
        
        
        public DateOnly Date { get; set; }
        
        private int StaffId { get; set; }

    }
}
