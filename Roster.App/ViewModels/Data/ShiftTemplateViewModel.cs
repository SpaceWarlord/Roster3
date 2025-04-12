using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media;
using Roster.App.DTO;
using Roster.App.Services;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace Roster.App.ViewModels.Data
{
    public partial class ShiftTemplateViewModel: DataViewModel
    {
        [ObservableProperty]
        private string _id;

        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private WorkerViewModel _worker;

        [ObservableProperty]
        private ClientViewModel _client;

        [ObservableProperty]
        private DateTime _startTime;

        [ObservableProperty]
        private DateTime _endTime;

        [ObservableProperty]
        private Brush _backgroundColor;

        [ObservableProperty]
        private Brush _foregroundColor;

        public ShiftTemplateViewModel() //Needed for SyncFusion
        {
            Id = Guid.NewGuid().ToString();
        }

        public ShiftTemplateViewModel(string id, string? name, WorkerViewModel worker, ClientViewModel client, DateTime startTime, DateTime endTime)
        {
            Id = id;
            Name = name;
            Worker = worker;
            Client = client;
            StartTime = startTime;
            EndTime = endTime;
            if (Worker != null)
            {
                //BackgroundColor = Brush.Parse(worker.HighlightColor);
            }
            //Certificates = certificates;            
        }

        public override T ToDTO<T>()
        {
            /*
            AddressDTO aDTO = null;
            if (Address == null)
            {
                Debug.WriteLine("Address is null");
            }
            else
            {
                aDTO = Address.ToDTO<AddressDTO>();
            }
            */
            Debug.WriteLine("shift template id is " + Id);
            //Address.ToDTO<AddressDTO>();
            return (T)Convert.ChangeType(new ShiftTemplateDTO(Id, Name, Worker.ToDTO<WorkerDTO>(), Client.ToDTO<ClientDTO>(), StartTime.ToString(), EndTime.ToString()), typeof(T));
        }

        public async Task AddUpdate(ShiftTemplateService shiftTemplateService)
        {
            Debug.WriteLine("Called Save Async");
            IsModified = false;
            if (IsNew)
            {
                Debug.WriteLine("its new");
                IsNew = false;
                await shiftTemplateService.AddUpdate(ToDTO<ShiftTemplateDTO>());
            }
        }
    }
}
