using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;
using System.Security.Cryptography.X509Certificates;

namespace Roster.Models
{
    public class ShiftTemplate:BaseModel
    {
        [Key]
        public string Id { get; set; }       
        public string? Name { get; set; }
        public string WorkerId { get; set; }
        public string ClientId { get; set; }

        [ForeignKey("WorkerId")] // for a shadow property to the Address ID FK
        public virtual Worker? Worker { get; set; }

        [ForeignKey("ClientId")] // for a shadow property to the Address ID FK
        public virtual Client? Client { get; set; }
        public string? Day { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }        

        /*
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
        */
        public ShiftTemplate()
        {
            Id=Guid.NewGuid().ToString();
        }

        public ShiftTemplate(string id)
        {
            Id = id;
        }

        /*
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
        */
    }
}
