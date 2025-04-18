using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.DTO
{
    public class CertificateDTO:BaseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CertLength { get; set; }
        public bool Infinite { get; set; }
        public CertificateDTO(string id, string name, string description, int certLength, bool infinite) 
        {
            Id = id;
            Name = name;
            Description = description;
            CertLength = certLength;
            Infinite = infinite;
        }
    }
}
