using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roster.Models;
using Microsoft.UI.Xaml;
using ABI.System;
using Roster.App.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Roster.App.ViewModels
{
    public partial class UserViewModel : BaseViewModel
    {       
        private User _model { get; }       

        public int Id { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Username is Required")]
        [MinLength(2, ErrorMessage = "Name should be longer than one character")]
        private string _username = string.Empty;


        public UserViewModel(User model = null)
        {
            _model = model ?? new User();

            //UpdateUsers(context.Users.ToList());
            //Users.CollectionChanged += this.OnCollectionChanged;            
        }

        /// <summary>
        /// Saves user data that has been edited.
        /// </summary>
        public async Task SaveAsync()
        {            
            IsModified = false;
            if (IsNew)
            {
                IsNew = false;
                await App.Repository.Users.UpsertAsync(_model);
                //App.ViewModel.Customers.Add(this);
            }

            //await App.Repository.Customers.UpsertAsync(Model);
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        public async Task DeleteAsync()
        {
            await App.Repository.Users.UpsertAsync(_model);
        }

        /*
        public void UpdateUsers(List<User> users)
        {
            Users.Clear();
            Debug.WriteLine("TTotal users: " + users.Count);
            foreach (User user in users)
            {
                Debug.WriteLine("User: " + user.Username);
                Users.Add(user);
            }
        }
        */




        /*
        [RelayCommand]
        public void DeleteUser1(object o)
        {
            Debug.WriteLine("Called Delete User");
            if (o != null)
            {
                int id = int.Parse(o.ToString());


                
                 //https://stackoverflow.com/questions/2471433/how-to-delete-an-object-by-id-with-entity-framework
                 
                using (context)
                {
                    try
                    {
                        context.Users.Remove((User)new User() { Id = id });
                        context.SaveChanges();
                    }
                    catch (System.Exception ex)
                    {
                        if (!context.Users.Any(i => i.Id == id))
                        {
                            Debug.WriteLine("User was not found with Id: " + id);
                            return;
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                }
            }
        }
*/
    }
}
