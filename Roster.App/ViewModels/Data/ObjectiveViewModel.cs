using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media;
using Roster.App.DTO;
using Roster.App.Services;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Roster.App.ViewModels.Data
{
    public partial class ObjectiveViewModel : DataViewModel
    {
        [ObservableProperty]
        [Required]
        private string _id;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private Priority priorityRating;

        [ObservableProperty]
        private DateTimeOffset _dateAdded;

        [ObservableProperty]
        private DateTimeOffset _completeBy;

        [ObservableProperty]
        private bool _completed;
        
        [ObservableProperty]
        private WorkerViewModel _worker;

        [ObservableProperty]
        private ClientViewModel _client;
              
        public ObservableCollection<RouteViewModel>? Routes { get; set; }



        public ObjectiveViewModel() //needed for syncfusion
        {
            Id = Guid.NewGuid().ToString();
        }

        public ObjectiveViewModel(string id, string name, string description, Priority priorityRating, DateTimeOffset dateAdded, DateTimeOffset
            completeBy, bool completed, WorkerViewModel worker, ClientViewModel client)
        {
            Id = id;
            Name = name;
            Description = description;
            PriorityRating = priorityRating;
            DateAdded = dateAdded;
            CompleteBy = completeBy;
            Completed = completed;
            Worker = worker;
            Client = client;                                 
        }

        public async Task AddUpdate(ObjectiveService objectiveService)
        {
            Debug.WriteLine("Called Save Async");
            IsModified = false;
            if (IsNew)
            {
                Debug.WriteLine("its new");
                IsNew = false;
                await objectiveService.AddUpdate(ToDTO<ObjectiveDTO>());
            }
        }

        public override T ToDTO<T>()
        {                       
            WorkerDTO worker = new WorkerDTO(Worker);
            ClientDTO client = new ClientDTO(Client);
            return (T)Convert.ChangeType(new ObjectiveDTO(Id, Name, Description, PriorityRating, DateAdded, CompleteBy, Completed, worker, client), typeof(T));
        }

        public override T ToModel<T>()
        {
            Objective s = new Objective()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                PriorityRating = PriorityRating,
                DateAdded = DateAdded,
                CompleteBy = CompleteBy,
                Completed = Completed,
                Worker = Worker.ToModel<Worker>(),
                Client = Client.ToModel<Client>()

            };
            return (T)Convert.ChangeType(s, typeof(T));
        }
    }
}
