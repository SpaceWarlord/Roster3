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
using System.Xml.Linq;
using Windows.Networking;

namespace Roster.App.ViewModels
{
    public partial class ClientViewModel: PersonViewModel
    {        
        public ObservableCollection<ClientPageViewModel> Clients;
        public Client Model { get; }


        [ObservableProperty]
        private byte _riskCategory;

        [ObservableProperty]
        private string? _genderPreference;

        public ObservableCollection<Shift> Shifts { get; set; }

        public ClientViewModel(Client model = null):base(model)
        {
            Model = model ?? new Client();
        }

        /*
        public ClientViewModel(Client model):base(model.FirstName, model.LastName, model.Nickname, model.Gender)
        {
            RiskCategory = model.RiskCategory;
            GenderPreference = model.GenderPreference;

            

            if (model.Customer == null)
            {
                Task.Run(() => LoadCustomer(Model.CustomerId));
            }

            
            //Clients = new ObservableCollection<ClientXViewModel>();            
            //UpdateClients(context.Clients.ToList());
            //Clients.CollectionChanged += this.OnCollectionChanged;
            //Categories = context.IngredientCategories.Where(p => p.ParentId != null).ToList();            
        }               
        */
             


        /*

         /// <summary>
        /// Gets the customers full (first + last) name.
        /// </summary>
        public string Name => IsNewCustomer && string.IsNullOrEmpty(FirstName)
        && string.IsNullOrEmpty(LastName) ? "New customer" : $"{FirstName} {LastName}";

        private bool _isNewCustomer;

        /// <summary>
        /// Gets or sets a value that indicates whether this is a new customer.
        /// </summary>

        public bool IsNewCustomer
        {
            get => _isNewCustomer;
            set => Set(ref _isNewCustomer, value);
        }
        */
        

        /*
        public void UpdateClients(List<ClientPageViewModel> client)
        {           
            Clients.Clear();
            //Debug.WriteLine("TTotal users: " + users.Count);
            foreach (ClientPageViewModel c in client)
            {
                Debug.WriteLine("Client: " + c.FirstName + " " + c.LastName);
                Clients.Add(c);
            }            
        }
        */
        void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("modified collection");
            //e.Action = NotifyCollectionChangedAction.
            if (e.NewItems != null)
            {
                Debug.WriteLine("New items to add");
                foreach (Client newItem in e.NewItems)
                {
                    Debug.WriteLine("New User: Id: " + newItem.Id + " First Name " + newItem.FirstName);
                    //ModifiedItems.Add(newItem);

                    //Add listener for each item on PropertyChanged event
                    context.Clients.Add(newItem);
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
                //context.SaveChanges();
            }

            if (e.OldItems != null)
            {
                foreach (Client oldItem in e.OldItems)
                {
                    //ModifiedItems.Add(oldItem);

                    context.Clients.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            context.SaveChanges();
        }

        //public static Client CreateClient(string firstName, string lastName, string nickname, string gender, string dob, string email, string phone, Color highlightColor, IAddress address, byte riskCategory, string genderPreference) => new(firstName, lastName, nickname, gender, dob, email, phone, highlightColor, address, riskCategory, genderPreference);
        //public static ClientPageViewModel CreateClient(string firstName, string lastName, string nickname, string gender, string dob, string email, string phone, Color highlightColor, AddressModel address, byte riskCategory, string genderPreference) => new(firstName, lastName, nickname, gender, dob, email, phone, highlightColor, address, riskCategory, genderPreference);
        
    }
}
