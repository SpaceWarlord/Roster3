using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Roster.Models;
using System.Collections.Specialized;
using System.Drawing;
using Roster.App.Services;
using CommunityToolkit.WinUI;
using Roster.App.ViewModels.Data;

namespace Roster.App.ViewModels.Page
{
    public partial class WorkerPageViewModel: BaseViewModel
    {
        private WorkerService WorkerService { get; set; }
        public ObservableCollection<WorkerViewModel> Workers;

        public WorkerPageViewModel()
        {
            Debug.WriteLine("-- WorkersPageViewModel Constructor--");
            Workers = new ObservableCollection<WorkerViewModel>();
            WorkerService = new WorkerService(new RosterDBContext());
            //UpdateWorkers(context.Workers.ToList());
            //Workers.CollectionChanged += this.OnCollectionChanged;
            //Categories = context.IngredientCategories.Where(p => p.ParentId != null).ToList();
        }

        /// <summary>
        /// Saves worker to database then clears fields 
        /// </summary>
        public async Task AddUpdateWorkerToDB(WorkerViewModel worker)
        {
            Debug.WriteLine("--AddWorkerToDb--");
            await worker.AddUpdate(WorkerService);            
        }

        public async Task GetWorkersListAsync()
        {
            Debug.WriteLine("-- Get Worker List Async --");
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
                    Debug.WriteLine("adding Id: + " + c.Id + " First Name: " + c.FirstName + " Last Name: " + c.LastName);
                    AddressViewModel aVM = new AddressViewModel(c.Address.Id, c.Address.Name, c.Address.UnitNum, c.Address.StreetNum, c.Address.StreetName, c.Address.StreetType, c.Address.Suburb, "Paris");
                    WorkerViewModel workerViewModel = new WorkerViewModel(c.Id, c.FirstName, c.MiddleName, c.LastName, c.Nickname, c.Gender, c.DateOfBirth, c.Phone, c.Email, c.HighlightColor, aVM);
                    if (workerViewModel.FirstName != null)
                    {
                        Debug.WriteLine("Not null: Id" + workerViewModel.Id + " name: " + workerViewModel.FullName);
                        Workers.Add(workerViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total workers after: " + workers.Count());
                IsLoading = false;
            });
        }

        /*
        public void UpdateWorkers(List<WorkerViewModel> worker)
        {
            Workers.Clear();
            //Debug.WriteLine("TTotal users: " + users.Count);
            foreach (WorkerViewModel w in worker)
            {
                Debug.WriteLine("Worker: " + w.FirstName +  " " + w.LastName);
                Workers.Add(w);
            }
        }
        */
        /*
        void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("modified collection");
            //e.Action = NotifyCollectionChangedAction.
            if (e.NewItems != null)
            {
                Debug.WriteLine("New items to add");
                foreach (Worker newItem in e.NewItems)
                {
                    Debug.WriteLine("New User: Id: " + newItem.Id + " First Name " + newItem.FirstName);
                    //ModifiedItems.Add(newItem);

                    //Add listener for each item on PropertyChanged event
                    //context.Workers.Add(newItem);
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
                //context.SaveChanges();
            }

            if (e.OldItems != null)
            {
                foreach (Worker oldItem in e.OldItems)
                {
                    //ModifiedItems.Add(oldItem);

                    //context.Workers.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            //context.SaveChanges();
        }
        */
        //public static Worker CreateWorker(string firstName, string lastName, string nickname, string gender, string dob, string email, string phone, Color highlightColor) => new(firstName, lastName, nickname, gender, dob, email, phone, highlightColor);


        /*
        [RelayCommand]
        public void AddWorker(Worker worker)
        {
            Debug.WriteLine("Called Add Worker");
            Debug.WriteLine("name is " + worker.FullName);
            if (worker != null)
            {
                WorkerViewModel i = new WorkerViewModel()
                {
                    Id = worker.Id,
                    FirstName = worker.FirstName,
                    LastName = worker.LastName,
                    Nickname = worker.Nickname,
                    Gender = worker.Gender,
                    Email = worker.Email,
                    Phone = worker.Phone,
                    FullName = worker.FullName,                    
                };
                Workers.Add(i);
                //i.Name = string.Empty;
                //i.RemoveErrors();

            }
            else
            {
                Debug.WriteLine("Error: Worker was null");
            }
        }
        */
    }
}
