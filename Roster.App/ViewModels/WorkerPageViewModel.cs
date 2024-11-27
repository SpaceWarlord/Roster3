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

namespace Roster.App.ViewModels
{
    public partial class WorkerPageViewModel: BaseViewModel
    {        
        public ObservableCollection<Worker> Worker;

        public WorkerPageViewModel()
        {
            Worker = new ObservableCollection<Worker>();
            UpdateWorkers(context.Workers.ToList());
            Worker.CollectionChanged += this.OnCollectionChanged;
            //Categories = context.IngredientCategories.Where(p => p.ParentId != null).ToList();
        }

        public void UpdateWorkers(List<Worker> worker)
        {
            Worker.Clear();
            //Debug.WriteLine("TTotal users: " + users.Count);
            foreach (Worker w in worker)
            {
                Debug.WriteLine("Worker: " + w.FirstName +  " " + w.LastName);
                Worker.Add(w);
            }
        }

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
                    context.Workers.Add(newItem);
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
                //context.SaveChanges();
            }

            if (e.OldItems != null)
            {
                foreach (Worker oldItem in e.OldItems)
                {
                    //ModifiedItems.Add(oldItem);

                    context.Workers.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            context.SaveChanges();
        }

        public static Worker CreateWorker(string firstName, string lastName, string nickname, string gender, string dob, string email, string phone, Color highlightColor) => new(firstName, lastName, nickname, gender, dob, email, phone, highlightColor);

        [RelayCommand]
        public void AddWorker(Worker worker)
        {
            Debug.WriteLine("Called Add Worker");
            Debug.WriteLine("name is " + worker.FullName);
            if (worker != null)
            {
                Worker i = new Worker()
                {
                    FirstName = worker.FirstName,
                    LastName = worker.LastName,
                    Nickname = worker.Nickname,
                    Email = worker.Email,
                    Phone = worker.Phone,
                    FullName = worker.FullName,                    
                };
                Worker.Add(i);
                //i.Name = string.Empty;
                //i.RemoveErrors();

            }
            else
            {
                Debug.WriteLine("Error: Worker was null");
            }
        }
    }
}
