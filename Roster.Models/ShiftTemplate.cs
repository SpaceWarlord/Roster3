using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;

namespace Roster.Models
{
    public class ShiftTemplate
    {
        [Key]
        public required string Id { get; set; }       

        public required string Name { get; set; }
        public string Day { get; set; }


        public required string StartTime { get; set; }


        public required string EndTime { get; set; }
        

        [ForeignKey("StartAddressId")] // Shadow FK
        public virtual Address StartLocation { get; set; }

        [ForeignKey("EndAddressId")] // Shadow FK
        public virtual Address EndLocation { get; set; }


        public byte TravelTime { get; set; }


        public short MaxTravelDistance { get; set; }        


        public char ShiftType { get; set; }


        public bool Reoccuring { get; set; }

        public bool IsAllDay { get; set; }
        public Brush BackgroundColor { get; set; }
        public Brush ForegroundColor { get; set; }

        public List<ShiftWorker> ShiftWorkers { get; set; }

        public int ClientId { get; set; } //1 client per shift
        public Client Client { get; set; } = null;

        public List<Route> Routes { get; set; }

        public ShiftTemplate()
        {

        }
        public ShiftTemplate(string startTime, string endTime, byte travelTime, short maxTravelDistance, ShiftAddress startLocation, ShiftAddress endLocation, char shiftType, bool reocurring, Client client)
        {
            StartTime = startTime;
            EndTime = endTime;
            TravelTime = travelTime;
            MaxTravelDistance = maxTravelDistance;
            StartLocation = startLocation;
            EndLocation = endLocation;
            ShiftType = shiftType;
            Reoccuring = reocurring;
            Client = client;
            //Location = location;
            //CaseNoteCompleted = caseNoteCompleted;            
        }
    }
}
