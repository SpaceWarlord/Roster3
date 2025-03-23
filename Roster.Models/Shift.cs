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
        public int ShiftId { get; protected set; }

        /*
        private string startDate;
        public string StartDate
        {
            get
            {
                if (startDate == string.Empty)
                {
                    return DateTimeOffset.Now;
                }
                return DateTimeOffset.Parse(StartDate);

            }
            set => SetProperty(ref startDate, value);
        }*/

        
        public string Day {  get; set; }

        
        public string StartTime {  get; set; }

        
        public string EndTime {  get; set; }

        //public virtual ShiftAddress StartLocation { get; set; }
        //public virtual ShiftAddress EndLocation { get; set; }

        [ForeignKey("StartAddressId")] // Shadow FK
        public virtual Address StartLocation { get; set; }

        [ForeignKey("EndAddressId")] // Shadow FK
        public virtual Address EndLocation { get; set; }

        
        public byte TravelTime { get; set; }

        
        public short MaxTravelDistance { get; set; }

        //[ObservableProperty]
        //private Address _startLocation;
        
       

        /*
        [ObservableProperty]
        private Address _startLocation;

        [ObservableProperty]        
        private Address _endLocation;

        */

        
        public char ShiftType { get; set; }

        
        public bool Reoccuring { get; set; }

        /*
        [ObservableProperty]
        private ShiftTask _shiftTaskId;

        public ShiftTask ShiftTask { get; set; }
        */
        
        public bool CaseNoteCompleted {  get; set; }
        
        public List<ShiftWorker> ShiftWorkers { get; set; }
        
        public int ClientId { get; set; } //1 client per shift
        public Client Client { get; set; } = null;  

        public List<Route> Routes { get; set; }

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
        
    }
}
