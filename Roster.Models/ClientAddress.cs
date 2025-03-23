using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    [Table("ClientAddress", Schema = "TPT")]
    public class ClientAddress : Address, IAddress
    {
        string IAddress.Id { get => Id; }

        string IAddress.AddressType
        {
            get => typeof(ClientAddress).Name;
        }

        public virtual Client? Client { get; set; }
        string IAddress.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string? IAddress.UnitNum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddress.StreetNum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddress.StreetName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddress.StreetType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IAddress.SuburbId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Suburb IAddress.Suburb { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddress.City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /*
        [Required]
        [Key]
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
        //public virtual ICollection<Client> Clients { get; } = []; // Optional
        public virtual Address Address { get; set; } = new();                       

        int IAddress.Id { get => AddressId; }



        string IAddress.AddressType
        {
            get => typeof(ClientAddress).Name;
            //set => AddressType = value;
        }            
        
        string IAddress.Name
        {
            get => Address.Name;
            set => Address.Name = value;
        }                

        string IAddress.UnitNum
        {
            get => Address.UnitNum;
            set => Address.UnitNum = value;
        }
        string IAddress.StreetNum
        {
            get => Address.StreetNum;
            set => Address.StreetNum = value;
        }
        string IAddress.StreetName
        {
            get => Address.StreetName;
            set => Address.StreetName = value;
        }

        string IAddress.StreetType
        {
            get => Address.StreetType;
            set => Address.StreetType = value;
        }

        int IAddress.SuburbId
        {
            get => Address.SuburbId;
            set => Address.SuburbId = value;
        }

        Suburb IAddress.Suburb
        {
            get => Address.Suburb;
            set => Address.Suburb = value;
        }
        string IAddress.City
        {
            get => Address.City;
            set => Address.City = value;
        }

        */
    }
}