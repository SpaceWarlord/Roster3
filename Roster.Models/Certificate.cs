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
        public int Id { get; set; }        
        public string Name { get; set; }       
        public int CertLength { get; set; }        
        public bool Infinite { get; set; }

        public Certificate(string name, int certLength, bool infinite)
        {
            Name = name;
            CertLength = certLength;
            Infinite = infinite;
        }
    }
}
