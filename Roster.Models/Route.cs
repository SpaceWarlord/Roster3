using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class Route:BaseModel
    {
        [Key]
        public int RouteId { get; set; }
        string Name {  get; set; }
        [ForeignKey("StartAddressId")] // Shadow FK
        public virtual Address StartAddress { get; set; }

        [ForeignKey("EndAddressId")] // Shadow FK
        public virtual Address EndAddress { get; set; }
        public float Distance {  get; set; }       
        /*
        public Route(string name, Address startAddress, Address endAddress, float distance)
        {
            Name = name;
            StartAddress = startAddress;
            EndAddress = endAddress;
            Distance = distance;
        }
        */
    }
}