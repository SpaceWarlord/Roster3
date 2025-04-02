using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class Shift
    {
        [Key]
        public required string Id { get; set; }     
        
        public required string Name { get; set; }
        
        public string? Day {  get; set; }
        
        public required string StartTime {  get; set; }
        
        public required string EndTime {  get; set; }

        /*
        [ForeignKey("StartAddressId")] // Shadow FK
        public virtual Address StartLocation { get; set; }
        */

        public Address? StartLocation { get; set; }

        /*
        [ForeignKey("EndAddressId")] // Shadow FK
        public virtual Address EndLocation { get; set; }
        */

        public Address? EndLocation { get; set; }
        public byte TravelTime { get; set; }
        
        public short MaxTravelDistance { get; set; }        
        
        public char ShiftType { get; set; }
        
        public bool Reoccuring { get; set; }       
        
        public bool CaseNoteCompleted {  get; set; }
        
        public List<ShiftWorker>? ShiftWorkers { get; set; }

        /*
        public int ClientId { get; set; } //1 client per shift
        public Client Client { get; set; } = null;
        */

        public Client? Client { get; set; }
        public string? BackgroundColor { get; set; }
        public string? ForegroundColor { get; set; }

        public List<Route>? Routes { get; set; }


        /*
        public Shift()
        {

        }
        public Shift(string startTime, string endTime, byte travelTime, short maxTravelDistance, ShiftAddress startLocation, ShiftAddress endLocation, char shiftType, bool reocurring, Client client)
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