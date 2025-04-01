using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Data
{
    public partial class ShiftViewModel: BaseViewModel
    {
        [ObservableProperty]
        [Required]
        private string _id;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private DateTime _startTime;

        [ObservableProperty]
        private DateTime _endTime;

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
        private ClientViewModel _client;
        

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

        

        [ForeignKey("StartAddressId")] // Shadow FK
        public virtual AddressViewModel StartLocation { get; set; }

        [ForeignKey("EndAddressId")] // Shadow FK
        public virtual AddressViewModel EndLocation { get; set; }

        public ObservableCollection<RouteViewModel>? Routes { get; set; }
        
        

        public ShiftViewModel()
        {
            
        }

        
        public ShiftViewModel(string id)
        {
            Id = id;
        }


        public ShiftViewModel(string id, string name, DateTime startTime, DateTime endTime, byte travelTime, short maxTravelDistance, AddressViewModel startLocation, AddressViewModel endLocation, char shiftType, bool reocurring, ClientViewModel client)
        {
            Id = id;
            Name = name;
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
