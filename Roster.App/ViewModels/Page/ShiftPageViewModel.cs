using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Roster.App.ViewModels.Data;
using CommunityToolkit.WinUI;
using Roster.App.Services;

namespace Roster.App.ViewModels.Page
{
    public partial class ShiftPageViewModel: BaseViewModel
    {
        private ShiftService ShiftService { get; set; }
        private WorkerService WorkerService { get; set; }
        private ClientService ClientService { get; set; }
        private AddressService AddressService { get; set; }


        public ObservableCollection<ShiftViewModel> Shifts { get; set; }
        public ObservableCollection<WorkerViewModel> Workers { get; set; }
        public ObservableCollection<ClientViewModel> Clients { get; set; }
        public ObservableCollection<AddressViewModel> Addresses { get; set; }

        /*
        public async static ShiftTemplatePageViewModel Create()
        {
            ObservableCollection<ShiftTemplateViewModel> ShiftTemplates = new ObservableCollection<ShiftTemplateViewModel>();
            ObservableCollection<WorkerViewModel>  Workers = new ObservableCollection<WorkerViewModel>();
            ObservableCollection<ClientViewModel>  Clients = new ObservableCollection<ClientViewModel>();
            GetShiftTemplatesListAsync();
            GetWorkersListAsync();
            GetClientsListAsync();
            return new ShiftTemplatePageViewModel();
        }

        private ShiftTemplatePageViewModel()
        {
            Debug.WriteLine("-- ShiftTemplatePageViewModel Constructor--");
            
            ShiftTemplateService = new ShiftTemplateService(new RosterDBContext());
            WorkerService = new WorkerService(new RosterDBContext());
            ClientService = new ClientService(new RosterDBContext());           
        }
        */


        public ShiftPageViewModel()
        {
            Debug.WriteLine("-- ShiftPageViewModel Constructor--");
            Shifts = new ObservableCollection<ShiftViewModel>();
            Workers = new ObservableCollection<WorkerViewModel>();
            Clients = new ObservableCollection<ClientViewModel>();
            Addresses = new ObservableCollection<AddressViewModel>();
            ShiftService = new ShiftService(new RosterDBContext());
            WorkerService = new WorkerService(new RosterDBContext());
            ClientService = new ClientService(new RosterDBContext());
            AddressService = new AddressService(new RosterDBContext());
            
            GetShiftsListAsync();
            GetWorkersListAsync();
            GetClientsListAsync();
            GetAddressesListAsync();

        }

        /// <summary>
        /// Saves shift to database 
        /// </summary>
        public async Task AddUpdateShiftToDB(ShiftViewModel shift)
        {
            Debug.WriteLine("--AddUpdateShiftToDb--");
            await shift.AddUpdate(ShiftService);
        }

        public async Task GetShiftsListAsync()
        {
            Debug.WriteLine("-- Get Shifts List Async --");
            //(CommunityToolkit.Helpers)
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var shifts = await ShiftService.GetAll();

            Debug.WriteLine("Total shifts: " + shifts.Count);

            await dispatcherQueue.EnqueueAsync(() =>
            {
                Shifts.Clear();

                foreach (var s in shifts)
                {
                    Debug.WriteLine("adding Id: + " + s.Id + " Name: " + s.Name);
                    //AddressViewModel aVM = new AddressViewModel(c.Address.Name, c.Address.UnitNum, c.Address.StreetNum, c.Address.StreetName, c.Address.StreetType, c.Address.Suburb, "Paris");
                    //AddressViewModel WorkerAddress = new AddressViewModel(c.Worker.Address.Name, c.Worker.Address.UnitNum, c.Worker.Address.StreetNum, c.Worker.Address.StreetName, c.Worker.Address.StreetType, "", "Adelaide");
                    //AddressViewModel ClientAddress = new AddressViewModel(c.Worker.Address.Name, c.Worker.Address.UnitNum, c.Worker.Address.StreetNum, c.Worker.Address.StreetName, c.Worker.Address.StreetType, "", "Adelaide");

                    /*WorkerViewModel worker = new WorkerViewModel(c.Worker.Id, c.Worker.FirstName, c.Worker.MiddleName, c.Worker.LastName, c.Worker.Nickname,
                        c.Worker.Gender, c.Worker.DateOfBirth, c.Worker.Phone, c.Worker.Email, c.Worker.HighlightColor, WorkerAddress);
                    */

                    WorkerViewModel worker = WorkerViewModel.Create(s.Worker);
                    AddressViewModel startLocation = AddressViewModel.Create(s.StartLocation);
                    AddressViewModel endLocation = AddressViewModel.Create(s.EndLocation);

                    /*ClientViewModel client = new ClientViewModel(c.Client.Id, c.Client.FirstName, c.Client.MiddleName, c.Client.LastName, c.Client.Nickname, c.Client.Gender,
                        c.Client.DateOfBirth, c.Client.Phone, c.Client.Email, c.Client.HighlightColor, ClientAddress, c.Client.NDISNumber, c.Client.RiskCategory, c.Client.GenderPreference);*/
                    ClientViewModel client = ClientViewModel.Create(s.Client);
                    ShiftViewModel shiftViewModel = new ShiftViewModel(s.Id, s.Name, s.Description, s.StartDate, s.EndDate, s.StartTime, s.EndTime, worker, client, s.TravelTime, 
                        s.MaxTravelDistance, startLocation, endLocation, s.ShiftType, s.Reoccuring, s.CaseNoteCompleted);
                    if (shiftViewModel.Name != null)
                    {
                        Debug.WriteLine("Not null: Id" + shiftViewModel.Id);
                        Shifts.Add(shiftViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total shift templates after: " + shifts.Count);
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

        public async Task GetAddressesListAsync()
        {
            Debug.WriteLine("-- Get Addresses List Async --");
            //(CommunityToolkit.Helpers)
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var addresses = await AddressService.GetAll();

            Debug.WriteLine("Total addresses: " + addresses.Count);

            await dispatcherQueue.EnqueueAsync(() =>
            {
                Addresses.Clear();

                foreach (var a in addresses)
                {
                    Debug.WriteLine("adding Id: + " + a.Id + " Name: " + a.Name);
                    //AddressViewModel aVM = new AddressViewModel(c.Address.Name, c.Address.UnitNum, c.Address.StreetNum, c.Address.StreetName, c.Address.StreetType, c.Address.Suburb, "Paris");
                    AddressViewModel addressViewModel = new AddressViewModel(a.Id, a.Name, a.UnitNum, a.StreetNum, a.StreetName, a.StreetType, a.Suburb, a.City);
                    if (addressViewModel.Name != null)
                    {
                        Debug.WriteLine("Not null: Id" + addressViewModel.Id);
                        Addresses.Add(addressViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total addresses after: " + Addresses.Count);
                IsLoading = false;
            });
        }
    }
}
