using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class Certificate
    {
        public string Id { get; set; }        
        public required string Name { get; set; }       
        public int CertLength { get; set; }        
        public bool Infinite { get; set; }        
    }
}
