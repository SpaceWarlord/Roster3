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
    public partial class AddressPageViewModel: BaseViewModel
    {                
        public ObservableCollection<Address> Addresses;

        public AddressPageViewModel()
        {
            Addresses = new ObservableCollection<Address>();
            //App.Repository.Users.GetAsync();
            //UpdateAddresses(context.Addresses.ToList());
            Addresses.CollectionChanged += this.OnCollectionChanged;
            //Categories = context.IngredientCategories.Where(p => p.ParentId != null).ToList();
        }

        public void UpdateAddresses(List<Address> address)
        {
            Addresses.Clear();
            //Debug.WriteLine("TTotal users: " + users.Count);
            foreach (Address a in address)
            {
                //Debug.WriteLine("Address: " + c.FirstName + " " + c.LastName);
                Addresses.Add(a);
            }
        }

        void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("modified collection");
            //e.Action = NotifyCollectionChangedAction.
            if (e.NewItems != null)
            {
                Debug.WriteLine("New items to add");
                foreach (Address newItem in e.NewItems)
                {
                    //Debug.WriteLine("New User: Id: " + newItem.Id + " First Name " + newItem.FirstName);
                    //ModifiedItems.Add(newItem);

                    //Add listener for each item on PropertyChanged event
                    //context.Addresses.Add(newItem);
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
                //context.SaveChanges();
            }

            if (e.OldItems != null)
            {
                foreach (Address oldItem in e.OldItems)
                {
                    //ModifiedItems.Add(oldItem);

                    //context.Addresses.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            //context.SaveChanges();
        }

        public static AddressViewModel CreateAddress(string name, string unitNum, string streetNum, string streetName, string streetType, string suburb, string city) => new(name, unitNum, streetNum, streetName, streetType, suburb, city);

        [RelayCommand]
        public void AddAddress(Address address)
        {
            Debug.WriteLine("Called Add Address");
            Debug.WriteLine("name is " + address.Name);
            if (address != null)
            {
                Address a = new Address()
                {
                    Name = address.Name,
                    UnitNum = address.UnitNum,
                    StreetNum = address.StreetNum,
                    StreetName = address.StreetName,
                    StreetType = address.StreetType,
                    Suburb = address.Suburb,
                    City = address.City,
                };
                Addresses.Add(a);
                //i.Name = string.Empty;
                //i.RemoveErrors();

            }
            else
            {
                Debug.WriteLine("Error: Address was null");
            }
        }
    }
}
