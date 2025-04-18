using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.DTO
{
    public class ShiftDTO:BaseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public WorkerDTO Worker { get; set; }
        public ClientDTO Client { get; set; }
        public byte TravelTime;
        public short MaxTravelDistance;
        public AddressDTO StartLocation { get; set; }
        public AddressDTO EndLocation { get; set; }
        public char ShiftType;
        public bool Reoccuring;
        public bool CaseNoteCompleted;

        public ShiftDTO(string id, string name, string description, DateTimeOffset startDate, DateTimeOffset endDate, DateTimeOffset startTime, DateTimeOffset endTime,
            WorkerDTO worker, ClientDTO client, byte travelTime, short maxTravelDistance, AddressDTO startLocation, AddressDTO endLocation, char shiftType, bool reoccuring, bool caseNoteCompleted)
        {
            Id = id;
            Name = name;
            Description = description;            
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startTime;
            EndTime = endTime;
            Worker = worker;
            Client = client;
            TravelTime = travelTime;
            MaxTravelDistance = maxTravelDistance;
            StartLocation = startLocation;
            EndLocation = endLocation;
            ShiftType = shiftType;
            Reoccuring = reoccuring;
            CaseNoteCompleted = caseNoteCompleted;
        }
    }
}