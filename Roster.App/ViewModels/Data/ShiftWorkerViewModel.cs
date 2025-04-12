using CommunityToolkit.Mvvm.ComponentModel;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Data
{
    public partial class ShiftWorkerViewModel:BaseViewModel
    {
        [Key]
        public int Id { get; set; }
        public int ShiftId { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Shift is Required")]
        private Shift _shift;

        public int WorkerId { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Worker is Required")]
        private Worker _worker;

        [ObservableProperty]
        private DateOnly _startDateTime;

        [ObservableProperty]
        private DateOnly _endDateTime;

        [ObservableProperty]
        private ShiftAddress? _startLocation;

        [ObservableProperty]
        private ShiftAddress? _endLocation;

        public ObservableCollection<Route> Routes { get; set; }

        public ShiftWorkerViewModel() { }

        public ShiftWorkerViewModel(Shift shift, Worker worker, DateOnly startDateTime, DateOnly endDateTime)
        {
            Shift = shift;
            Worker = worker;
            _startDateTime = startDateTime;
            _endDateTime = endDateTime;
        }
    }
}
