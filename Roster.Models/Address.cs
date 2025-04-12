using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    [Table("Address", Schema = "TPT")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; protected set; }
        
        public string? Name { get; set; }

#nullable enable
        public string? UnitNum { get; set; }

#nullable disable
        public string StreetNum { get; set; } 
        
        public string StreetName { get; set; } 
        
        public string StreetType { get; set; }

        public string SuburbId {  get; set; }
        
        public Suburb Suburb { get; set; }
        
        public string City {  get; set; }   
        
        public Address()
        {
            Id=Guid.NewGuid().ToString();
        }

        public Address(string id)
        {
            Id = id;
        }
    }
}