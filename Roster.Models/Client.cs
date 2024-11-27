using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roster.Models
{

    [Table("Client", Schema = "TPT")]
    public class Client : Person
    {                
        //public virtual ClientAddress ClientAddress { get; set; }       
        
        public byte RiskCategory { get; set; }

#nullable enable
        public string? GenderPreference { get; set; }
#nullable disable

        //public ObservableCollection<Shift> Shifts { get; set; }

        
        public Client(): base(string.Empty, string.Empty, string.Empty, "", string.Empty, string.Empty, null, Color.Black)
        {
            
        }

        public Client(string firstName, string lastName, string nickname, string gender, string dob, string email, string phone, Color highlightColor, Address clientAddress, byte riskCategory, string genderPreference) : base(firstName, lastName, nickname, gender, dob, email, phone, highlightColor)
        {
            Address = clientAddress;
            RiskCategory = riskCategory;
            GenderPreference = genderPreference;
        }
        
        /*
        public Client(string firstName, string lastName, string nickname, string gender, string dob, string email,  string phone, Color highlightColor, IAddress clientAddress, byte riskCategory, string genderPreference) : base(firstName, lastName, nickname, gender, dob, email, phone, highlightColor)
        {
            ClientAddress = clientAddress as ClientAddress;
            RiskCategory = riskCategory;
            GenderPreference = genderPreference;
        }
        */
    }
}