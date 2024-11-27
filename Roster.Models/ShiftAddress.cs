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
        int IAddress.Id { get => AddressId; }

        string IAddress.AddressType
        {
            get => typeof(ShiftAddress).Name;
        }

#nullable enable
        public virtual Shift? Shift { get; set; }

#nullable disable

    }
}
