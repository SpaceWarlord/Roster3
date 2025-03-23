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
using Windows.Media.Audio;
using Microsoft.Extensions.Logging.Abstractions;
using Roster.App.Services;
using Microsoft.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Roster.App.DTO;

namespace Roster.App.ViewModels
{
    public partial class ClientViewModel: PersonViewModel
    {
        /// <summary>
        /// Gets or sets the client's risk category.
        /// </summary>

        [ObservableProperty]
        private byte _riskCategory;

#nullable enable

        /// <summary>
        /// Gets or sets the client's gender preference.
        /// </summary>

        [ObservableProperty]
        private string? _genderPreference;


        public ObservableCollection<Shift?>? Shifts { get; set; }

        //protected override Client _model => new();
        //protected Client _model => new();

        /// <summary>
        /// Saves client data that has been edited.
        /// </summary>
        //public async Task<bool> SaveAsync()
        public async Task SaveAsync(ClientService clientService)
        {
            Debug.WriteLine("Called Save Async. Name: " + FirstName);
            IsModified = false;
            if (IsNew)
            {
                Debug.WriteLine("its new");

                IsNew = false;
                //await clientService.Add(new ClientDTO(Id, FirstName, LastName, Nickname, Gender));
                await clientService.Add(ToDTO<ClientDTO>());
                /*
                var clientService = ((App)Application.Current).Services.GetService<ClientService>();
                if (clientService!=null)
                {
                    await clientService.Add(new DTO.ClientDTO(Id, FirstName, LastName, Nickname, Gender));
                }
                */
                //var myApp = Application.Current;
                //myApp.s
                //App.Services.
                //Roster.App.Services.
                //Roster.App.Services.ClientService.
                //App.ViewModel.Customers.Add(this);
                //return true;
            }
            //await App.Repository.Clients.UpsertAsync(_model);
            //return false;
            //await App.Repository.Customers.UpsertAsync(Model);
        }


        /// <summary>
        /// Deletes a client
        /// </summary>
        public async Task DeleteAsync()
        {
            //await App.Repository.Clients.DeleteAsync(Id);
        }

        //public ClientViewModel(Client model = null):base(model)

        /*
        public ClientViewModel(Client model = null) : base(model)
        {
            _model = model ?? new Client();
            FirstName = string.Empty;
            LastName = string.Empty;
            Nickname = string.Empty;
            Gender = string.Empty;
        }
        */

        /*
        public static ClientViewModel Create(Client model=null)
        {
            ClientViewModel clientViewModel = null;
            if (model == null)
            {
                //clientViewModel = new ClientViewModel();
            }
            else
            {

            }
            return null;
        }*/

#nullable enable
        public ClientViewModel(string firstName, string lastName, string nickname, string gender, string? dob, string? phone, string? email, string? highlightColor, AddressViewModel? address, byte riskCategory, string? genderPreference) 
            : base(firstName, lastName, nickname, gender, dob, phone, email, highlightColor, address)
        {
            Debug.WriteLine("-- ClientViewModel Constructor--");
            _riskCategory = riskCategory;
            _genderPreference = genderPreference;
            //_model= new ClientViewModel
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
                    //context.Clients.Add(newItem);
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
                //context.SaveChanges();
            }

            if (e.OldItems != null)
            {
                foreach (Client oldItem in e.OldItems)
                {
                    //ModifiedItems.Add(oldItem);

                    //context.Clients.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            //context.SaveChanges();
        }

        public override T ToDTO<T>()
        {
            AddressDTO aDTO = Address.ToDTO<AddressDTO>();
            //return new ClientDTO(Id, FirstName, LastName, Nickname, Gender, Dob, Phone, Email, HighlightColor, aDTO, RiskCategory, GenderPreference);
            //return (T) Convert.ChangeType(PlayerStats[type], typeof(T));
            return (T)Convert.ChangeType(new ClientDTO(Id, FirstName, LastName, Nickname, Gender, Dob, Phone, Email, HighlightColor, aDTO, RiskCategory, GenderPreference), typeof(T));
        }

        //public static Client CreateClient(string firstName, string lastName, string nickname, string gender, string dob, string email, string phone, Color highlightColor, IAddress address, byte riskCategory, string genderPreference) => new(firstName, lastName, nickname, gender, dob, email, phone, highlightColor, address, riskCategory, genderPreference);
        //public static ClientPageViewModel CreateClient(string firstName, string lastName, string nickname, string gender, string dob, string email, string phone, Color highlightColor, AddressModel address, byte riskCategory, string genderPreference) => new(firstName, lastName, nickname, gender, dob, email, phone, highlightColor, address, riskCategory, genderPreference);

    }
}
