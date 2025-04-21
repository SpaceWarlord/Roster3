using CommunityToolkit.WinUI;
using Roster.App.Services;
using Roster.App.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Page
{
    public partial class ObjectivePageViewModel:BaseViewModel
    {
        private ObjectiveService ObjectiveService { get; set; }
        private WorkerService WorkerService { get; set; }
        private ClientService ClientService { get; set; }       

        public ObservableCollection<ObjectiveViewModel> Objectives { get; set; }
        public ObservableCollection<WorkerViewModel> Workers { get; set; }
        public ObservableCollection<ClientViewModel> Clients { get; set; }
                
        public ObjectivePageViewModel()
        {
            Debug.WriteLine("-- ShiftPageViewModel Constructor--");
            Objectives = new ObservableCollection<ObjectiveViewModel>();
            Workers = new ObservableCollection<WorkerViewModel>();
            Clients = new ObservableCollection<ClientViewModel>();
            
            ObjectiveService = new ObjectiveService(new RosterDBContext());
            WorkerService = new WorkerService(new RosterDBContext());
            ClientService = new ClientService(new RosterDBContext());
            
            GetObjectivesListAsync();
            GetWorkersListAsync();
            GetClientsListAsync();            
        }

        /// <summary>
        /// Saves shift to database 
        /// </summary>
        public async Task AddUpdateObjectiveToDB(ObjectiveViewModel objective)
        {
            Debug.WriteLine("-- AddUpdateObjectiveToDb --");
            await objective.AddUpdate(ObjectiveService);
        }

        public async Task GetObjectivesListAsync()
        {
            Debug.WriteLine("-- Get Objectives List Async --");
            //(CommunityToolkit.Helpers)
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var objectives = await ObjectiveService.GetAll();

            Debug.WriteLine("Total objectives: " + objectives.Count);

            await dispatcherQueue.EnqueueAsync(() =>
            {
                Objectives.Clear();

                foreach (var s in objectives)
                {
                    Debug.WriteLine("adding Id: + " + s.Id + " Name: " + s.Name);                   
                    WorkerViewModel worker = WorkerViewModel.Create(s.Worker);                                                           
                    ClientViewModel client = ClientViewModel.Create(s.Client);
                    ObjectiveViewModel objectiveViewModel = new ObjectiveViewModel(s.Id, s.Name, s.Description, s.PriorityRating, s.DateAdded, s.CompleteBy, s.Completed, worker, client);
                    if (objectiveViewModel.Name != null)
                    {
                        Debug.WriteLine("Not null: Id" + objectiveViewModel.Id);
                        Objectives.Add(objectiveViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total objectives after: " + objectives.Count);
                IsLoading = false;
            });
        }

        public async Task GetWorkersListAsync()
        {
            Debug.WriteLine("-- Get Workers List Async --");

            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var workers = await WorkerService.GetAll(false);

            Debug.WriteLine("Total workers: " + workers.Count);

            await dispatcherQueue.EnqueueAsync(() =>
            {
                Workers.Clear();

                foreach (var c in workers)
                {
                    Debug.WriteLine("adding Id: + " + c.Id + " Name: " + c.FirstName);
                    //AddressViewModel aVM = new AddressViewModel(c.Address.Name, c.Address.UnitNum, c.Address.StreetNum, c.Address.StreetName, c.Address.StreetType, c.Address.Suburb, "Paris");
                    WorkerViewModel workerViewModel = new WorkerViewModel(c.Id, c.FirstName, c.MiddleName, c.LastName, c.Nickname, c.Gender, c.DateOfBirth, c.Phone, c.Email, c.HighlightColor, null);
                    if (workerViewModel.FirstName != null)
                    {
                        Debug.WriteLine("Not null: Id" + workerViewModel.Id);
                        Workers.Add(workerViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total workers after: " + Workers.Count);
                IsLoading = false;
            });
        }

        public async Task GetClientsListAsync()
        {
            Debug.WriteLine("-- Get Clients List Async --");
            //(CommunityToolkit.Helpers)
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var clients = await ClientService.GetAll();

            Debug.WriteLine("Total clients: " + clients.Count);

            await dispatcherQueue.EnqueueAsync(() =>
            {
                Clients.Clear();

                foreach (var c in clients)
                {
                    Debug.WriteLine("adding Id: + " + c.Id + " Name: " + c.FirstName);
                    //AddressViewModel aVM = new AddressViewModel(c.Address.Name, c.Address.UnitNum, c.Address.StreetNum, c.Address.StreetName, c.Address.StreetType, c.Address.Suburb, "Paris");
                    ClientViewModel clientViewModel = new ClientViewModel(c.Id, c.FirstName, c.MiddleName, c.LastName, c.Nickname, c.Gender, c.DateOfBirth, c.Phone, c.Email,
                        c.HighlightColor, null, c.NDISNumber, c.RiskCategory, c.GenderPreference);
                    if (clientViewModel.FirstName != null)
                    {
                        Debug.WriteLine("Not null: Id" + clientViewModel.Id);
                        Clients.Add(clientViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total clients after: " + Clients.Count);
                IsLoading = false;
            });
        }        
    }
}
