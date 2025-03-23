using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    [Table("ShiftAddress", Schema = "TPT")]
    public class ShiftAddress : Address, IAddress
    {
        string IAddress.Id { get => Id; }

        string IAddress.AddressType
        {
            get => typeof(ShiftAddress).Name;
        }

#nullable enable
        public virtual Shift? Shift { get; set; }
        string IAddress.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string? IAddress.UnitNum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddress.StreetNum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddress.StreetName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddress.StreetType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IAddress.SuburbId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Suburb IAddress.Suburb { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddress.City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

#nullable disable

    }
}
