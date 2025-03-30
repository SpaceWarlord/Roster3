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

namespace Roster.App.ViewModels
{
    public partial class ShiftPageViewModel: BaseViewModel
    {        
        public ObservableCollection<Shift> Shift;

        public ShiftPageViewModel()
        {
            Shift = new ObservableCollection<Shift>();
            
            Debug.WriteLine("total shifts " + Shift.Count);
            Shift.CollectionChanged += this.OnCollectionChanged;
            //Categories = context.IngredientCategories.Where(p => p.ParentId != null).ToList();
            Debug.WriteLine("hhahah");            

        }

        public void Loaded()
        {
            //UpdateShifts(context.Shifts.ToList());
        }
        public void UpdateShifts(List<Shift> shift)
        {
            Shift.Clear();
            //Debug.WriteLine("TTotal users: " + users.Count);
            foreach (Shift c in shift)
            {
                //Debug.WriteLine("Shift: " + c.FirstName + " " + c.LastName);
                Shift.Add(c);
            }
        }

        void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("modified collection");
            //e.Action = NotifyCollectionChangedAction.
            if (e.NewItems != null)
            {
                Debug.WriteLine("New items to add");
                foreach (Shift newItem in e.NewItems)
                {
                    //Debug.WriteLine("New User: Id: " + newItem.Id + " First Name " + newItem.FirstName);
                    //ModifiedItems.Add(newItem);
                    //Debug.WriteLine("zzzoop " + context.Shifts.Count());
                    //Add listener for each item on PropertyChanged event
                    //context.Shifts.Add(newItem);
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
                //context.SaveChanges();
            }

            if (e.OldItems != null)
            {
                foreach (Shift oldItem in e.OldItems)
                {
                    //ModifiedItems.Add(oldItem);

                    //context.Shifts.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            //context.SaveChanges();
        }

        /*
        public static Shift CreateShift(string startDate, string endDate, string startTime, string endTime, int travelTime, Staff staff, Client client, Location location, bool caseNoteCompleted) 
            => new(startDate, endDate, startTime, endTime, travelTime, staff, client, location, caseNoteCompleted);
        */

        /*
        public static Shift CreateShift(string startTime, string endTime, byte travelTime, short maxTravelDistance, ShiftAddress startLocation, ShiftAddress endLocation, char shiftType, bool reoccuring, Client client)
            => new(startTime, endTime, travelTime, maxTravelDistance, startLocation, endLocation, shiftType,  reoccuring, client);*/

        [RelayCommand]
        public void AddShift(Shift shift)
        {
            Debug.WriteLine("Called Add Shift");
            //Debug.WriteLine("name is " + client.Name);
            if (shift != null)
            {
                /*
                Shift i = new Shift()
                {                    
                    StartTime = shift.StartTime,
                    EndTime = shift.EndTime,
                    TravelTime = shift.TravelTime,
                    MaxTravelDistance = shift.MaxTravelDistance,
                    StartLocation = shift.StartLocation,
                    EndLocation = shift.EndLocation,
                    ShiftType = shift.ShiftType,
                    //ShiftWorker = shift.ShiftWorker,
                    Client = shift.Client,
                    //Location = shift.Location,
                    //CaseNoteCompleted = shift.CaseNoteCompleted,                   
                };
                Debug.WriteLine("id is " + i.Client.Id + " name " + i.Client.FullName);
                Shift.Add(i);                
                */
            }
            else
            {
                Debug.WriteLine("Error: Shift was null");
            }
        }
    }
}
