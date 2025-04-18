using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media;
using Roster.App.DTO;
using Roster.App.Services;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Data
{
    public partial class ShiftViewModel: DataViewModel
    {
        [ObservableProperty]
        [Required]
        private string _id;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private DateTimeOffset _startDate;

        [ObservableProperty]
        private DateTimeOffset _endDate;

        [ObservableProperty]
        private DateTimeOffset _startTime;

        [ObservableProperty]
        private DateTimeOffset _endTime;

        [ObservableProperty]
        private WorkerViewModel _worker;

        [ObservableProperty]
        private ClientViewModel _client;        

        [ObservableProperty]
        private AddressViewModel _startLocation;

        [ObservableProperty]
        private AddressViewModel _endLocation;
        
        [ObservableProperty]
        private bool _isAllDay;

        [ObservableProperty]
        private Brush _backgroundColor;

        [ObservableProperty]
        private Brush _foregroundColor;

        [ObservableProperty]
        private string _startTimeZone;

        [ObservableProperty]
        private string _endTimeZone;                
        
        [ObservableProperty]
        private byte _travelTime;

        [ObservableProperty]
        private short _maxTravelDistance;

        [ObservableProperty]
        private char _shiftType;

        [ObservableProperty]
        private bool _reoccuring;

        [ObservableProperty]
        private bool _caseNoteCompleted;

        /*

        [ForeignKey("StartAddressId")] // Shadow FK
        public virtual AddressViewModel StartLocation { get; set; }

        [ForeignKey("EndAddressId")] // Shadow FK
        public virtual AddressViewModel EndLocation { get; set; }

        */
        public ObservableCollection<RouteViewModel>? Routes { get; set; }
        
        

        public ShiftViewModel() //needed for syncfusion
        {
            Id = Guid.NewGuid().ToString();
        }               

        public ShiftViewModel(string id, string name, string description, DateTimeOffset startDate, DateTimeOffset endDate, DateTimeOffset startTime, DateTimeOffset endTime, 
            WorkerViewModel worker, ClientViewModel client, byte travelTime, short maxTravelDistance, AddressViewModel startLocation, AddressViewModel endLocation, 
            char shiftType, bool reocurring, bool caseNoteCompleted)
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
            Reoccuring = reocurring;
            CaseNoteCompleted = caseNoteCompleted;
            
            //Location = location;
            //CaseNoteCompleted = caseNoteCompleted;            
        }

        public async Task AddUpdate(ShiftService shiftService)
        {
            Debug.WriteLine("Called Save Async");
            IsModified = false;
            if (IsNew)
            {
                Debug.WriteLine("its new");
                IsNew = false;
                await shiftService.AddUpdate(ToDTO<ShiftDTO>());
            }
        }

        public override T ToDTO<T>()
        {
            //StartLocation = new AddressViewModel();
            AddressDTO startLocation = new AddressDTO(StartLocation);
            AddressDTO endLocation = new AddressDTO(EndLocation);
            WorkerDTO worker = new WorkerDTO(Worker);
            ClientDTO client = new ClientDTO(Client);
            return (T)Convert.ChangeType(new ShiftDTO(Id, Name, Description, StartDate, EndDate, StartTime, EndTime, 
                worker, client, TravelTime, MaxTravelDistance, startLocation, endLocation, ShiftType, Reoccuring, CaseNoteCompleted), typeof(T));
        }

        public override T ToModel<T>()
        {
            Shift s = new Shift()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                StartTime = StartTime,
                EndTime = EndTime,
                ShiftType = ShiftType,
                Reoccuring = Reoccuring,
                CaseNoteCompleted = CaseNoteCompleted,
            };
            return (T)Convert.ChangeType(s, typeof(T));
        }
    }
}
