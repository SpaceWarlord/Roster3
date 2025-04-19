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
    public partial class ClientPageViewModel:BaseViewModel
    {

        private ClientService ClientService { get; set; }
        public ObservableCollection<ClientViewModel> Clients;

        public ClientViewModel NewClient { get; set; }
        
        public ClientPageViewModel()
        { 
            Debug.WriteLine("-- ClientPageViewModel Constructor--");
            Clients = new ObservableCollection<ClientViewModel>();
            Clients.CollectionChanged += Client_CollectionChanged;
            ClientService = new ClientService(new RosterDBContext());
            //NewClient = new ClientViewModel(Guid.NewGuid().ToString(), "", "", "", "", "", "", "", "", "", null, "", 0, "");
            
        }

        private void Client_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            // What was the action that caused the event?
            Debug.WriteLine("Action for this event: {0}", e.Action);

            // They removed something. 
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Debug.WriteLine("Here are the OLD items:");
                foreach (ClientViewModel client in e.OldItems)
                {
                    Debug.WriteLine(client.ToString());
                }

            }

            // They added something. 
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // Now show the NEW items that were inserted.
                Debug.WriteLine("Here are the NEW items:");
                foreach (ClientViewModel client in e.NewItems)
                {
                    //Debug.WriteLine(client.ToString());
                    //await client.AddUpdate(ClientService);
                }
                //await GetClientsListAsync();
            }
        }

        /// <summary>
        /// Saves user to database then clears fields 
        /// </summary>
        public async Task AddUpdateClientToDB(ClientViewModel client)
        {
            Debug.WriteLine("--AddClientToDb--");
            await client.AddUpdate(ClientService);
            //await NewClient.AddUpdate(ClientService);
            NewClient = new ClientViewModel(Guid.NewGuid().ToString(), "", "", "", "", "M", null, "", "", "", null, "",0, "");
            //await GetClientsListAsync();
        }

        /*
        public async Task UpdateClient(ClientViewModel client)
        {
            //await client.
        }*/

        public async Task GetClientsListAsync()
        {
            Debug.WriteLine("-- Get Client List Async --");
            //(CommunityToolkit.Helpers)
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var clients = await ClientService.GetAll();

            /*
            var clients = await App.Repository.Clients.GetAsync();
            if (clients == null)
            {
                Debug.WriteLine("clients was null");
                return;
            }
            */
            Debug.WriteLine("Total clients: " + clients.Count);

            await dispatcherQueue.EnqueueAsync(() =>
            {
                Clients.Clear();

                foreach (var c in clients)
                {
                    Debug.WriteLine("adding Id: + " + c.Id + " First Name: " + c.FirstName + " Last Name: " + c.LastName);
                    AddressViewModel aVM = new AddressViewModel(c.Address.Id, c.Address.Name, c.Address.UnitNum, c.Address.StreetNum, c.Address.StreetName, c.Address.StreetType, c.Address.Suburb, "Paris");
                    ClientViewModel clientViewModel = new ClientViewModel(c.Id, c.FirstName, c.MiddleName, c.LastName, c.Nickname, c.Gender, c.DateOfBirth, c.Phone, c.Email, c.HighlightColor, aVM, c.NDISNumber, c.RiskCategory, c.GenderPreference);
                    if (clientViewModel.FirstName != null)
                    {
                        Debug.WriteLine("Not null: Id" + clientViewModel.Id + " name: " + clientViewModel.FullName);
                        Clients.Add(clientViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total clients after: " + clients.Count);
                IsLoading = false;
            });
        }

        [RelayCommand]
        public void AddClientOld(ClientViewModel client)
        {
            Debug.WriteLine("Called Add Client");
            Debug.WriteLine("name is " + client.FullName);
            if (client != null)
            {
                ClientViewModel c = new ClientViewModel(client.Id, client.FirstName, client.MiddleName, client.LastName, client.Nickname, client.Gender, client.DateOfBirth, client.Phone, client.Email, client.HighlightColor, 
                    client.Address, client.NDISNumber, client.RiskCategory, client.GenderPreference);
                /*
                ClientViewModel c = new ClientViewModel()
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    FullName = client.FullName,
                    Nickname = client.Nickname,
                    Gender = client.Gender,
                    DOB = client.DOB,
                    GenderPreference = client.GenderPreference,
                    Email = client.Email,
                    Phone = client.Phone,
                    HighlightColor = client.HighlightColor,
                };
                */
                Clients.Add(c);
                //i.Name = string.Empty;
                //i.RemoveErrors();

            }
            else
            {
                Debug.WriteLine("Error: Client was null");
            }
        }
    }
}
