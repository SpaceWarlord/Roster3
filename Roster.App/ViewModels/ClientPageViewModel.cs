using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels
{
    public partial class ClientPageViewModel:BaseViewModel
    {
        public ObservableCollection<ClientViewModel> Clients;

        
        public ClientPageViewModel() { }

        [RelayCommand]
        public void AddClient(ClientViewModel client)
        {
            Debug.WriteLine("Called Add Client");
            Debug.WriteLine("name is " + client.FullName);
            if (client != null)
            {
                ClientViewModel c = new ClientViewModel()
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    FullName = client.FullName,
                    Nickname = client.Nickname,
                    Gender = client.Gender,
                    Dob = client.Dob,
                    GenderPreference = client.GenderPreference,
                    Email = client.Email,
                    Phone = client.Phone,
                    HighlightColor = client.HighlightColor,
                };
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
