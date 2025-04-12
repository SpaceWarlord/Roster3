using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Roster.App.Helpers;
using Roster.App.Services;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Microsoft.UI.Dispatching;
using CommunityToolkit.Helpers;
using CommunityToolkit.Common.Extensions;
using CommunityToolkit.WinUI;
using System.Collections.Specialized;
using Roster.App.ViewModels.Data;

namespace Roster.App.ViewModels.Page
{
    public partial class Blah:BaseViewModel
    {
        [ObservableProperty]
        private string _name;

        public Blah(string name)
        {
            Name = name;
        }
    }
    public partial class ShiftTemplatePageViewModel : BaseViewModel
    {
        private ShiftTemplateService ShiftTemplateService { get; set; }
        private WorkerService WorkerService { get; set; }

        public ObservableCollection<Blah> Blahs { get; set; }
        public ObservableCollection<ShiftTemplateViewModel> ShiftTemplates { get; set; }
        public ObservableCollection<WorkerViewModel> Workers { get; set; }
        public ObservableCollection<ClientViewModel> Clients { get; set; }


        public ShiftTemplatePageViewModel()
        {
            Debug.WriteLine("-- ShiftTemplatePageViewModel Constructor--");
            ShiftTemplates = new ObservableCollection<ShiftTemplateViewModel>();
            Workers = new ObservableCollection<WorkerViewModel>();
            Clients = new ObservableCollection<ClientViewModel>();
            ShiftTemplateService = new ShiftTemplateService(new RosterDBContext());
            WorkerService = new WorkerService(new RosterDBContext());

            GetShiftTemplatesListAsync();
            GetWorkersListAsync();

        }

        /// <summary>
        /// Saves shift template to database 
        /// </summary>
        public async Task AddUpdateShiftTemplateToDB(ShiftTemplateViewModel shiftTemplate)
        {
            Debug.WriteLine("--AddUpdateShiftTemplateToDb--");
            await shiftTemplate.AddUpdate(ShiftTemplateService);
        }

        public async Task GetShiftTemplatesListAsync()
        {
            Debug.WriteLine("-- Get Shift Templates List Async --");
            //(CommunityToolkit.Helpers)
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var shiftTemplates = await ShiftTemplateService.GetAll();

            Debug.WriteLine("Total shift templates: " + shiftTemplates.Count());

            await dispatcherQueue.EnqueueAsync(() =>
            {
                ShiftTemplates.Clear();

                foreach (var c in shiftTemplates)
                {
                    Debug.WriteLine("adding Id: + " + c.Id + " Name: " + c.Name);
                    //AddressViewModel aVM = new AddressViewModel(c.Address.Name, c.Address.UnitNum, c.Address.StreetNum, c.Address.StreetName, c.Address.StreetType, c.Address.Suburb, "Paris");
                    //AddressViewModel WorkerAddress = new AddressViewModel(c.Worker.Address.Name, c.Worker.Address.UnitNum, c.Worker.Address.StreetNum, c.Worker.Address.StreetName, c.Worker.Address.StreetType, "", "Adelaide");
                    //AddressViewModel ClientAddress = new AddressViewModel(c.Worker.Address.Name, c.Worker.Address.UnitNum, c.Worker.Address.StreetNum, c.Worker.Address.StreetName, c.Worker.Address.StreetType, "", "Adelaide");

                    /*WorkerViewModel worker = new WorkerViewModel(c.Worker.Id, c.Worker.FirstName, c.Worker.MiddleName, c.Worker.LastName, c.Worker.Nickname,
                        c.Worker.Gender, c.Worker.DateOfBirth, c.Worker.Phone, c.Worker.Email, c.Worker.HighlightColor, WorkerAddress);
                    */

                    WorkerViewModel worker = WorkerViewModel.Create(c.Worker);

                    /*ClientViewModel client = new ClientViewModel(c.Client.Id, c.Client.FirstName, c.Client.MiddleName, c.Client.LastName, c.Client.Nickname, c.Client.Gender,
                        c.Client.DateOfBirth, c.Client.Phone, c.Client.Email, c.Client.HighlightColor, ClientAddress, c.Client.NDISNumber, c.Client.RiskCategory, c.Client.GenderPreference);*/
                    ClientViewModel client = ClientViewModel.Create(c.Client);
                    ShiftTemplateViewModel shiftTemplateViewModel = new ShiftTemplateViewModel(c.Id, c.Name, worker, client, DateTime.Parse(c.StartTime), DateTime.Parse(c.EndTime));
                    if (shiftTemplateViewModel.Name != null)
                    {
                        Debug.WriteLine("Not null: Id" + shiftTemplateViewModel.Id);
                        ShiftTemplates.Add(shiftTemplateViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total shift templates after: " + shiftTemplates.Count());
                IsLoading = false;
            });
        }

        public async Task GetWorkersListAsync()
        {
            Debug.WriteLine("-- Get Workers List Async --");
            //(CommunityToolkit.Helpers)
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var workers = await WorkerService.GetAll();

            Debug.WriteLine("Total workers: " + workers.Count());

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
                Debug.WriteLine("Total shift templates after: " + Workers.Count());
                IsLoading = false;
            });
        }
    }
}
