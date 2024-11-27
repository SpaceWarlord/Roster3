using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Roster.App.Main;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels
{
    public partial class LoginPageViewModel:BaseViewModel
    {
        public ObservableCollection<UserViewModel> Users;

        public LoginPageViewModel() 
        {
            Users = new ObservableCollection<UserViewModel>();
            Users.CollectionChanged += this.OnCollectionChanged;
        }

        [RelayCommand]
        private void Login(UserViewModel user)
        {
            Debug.WriteLine("Called Login");
            if (user != null)
            {                
                Debug.WriteLine("Username is " + user.Username);
                Application.Current.Resources["currentUser"] = user;
                //Application.Current.Properties["Timecap"] = timecap;
                //User currentUser = (Application.Current as App)?.CurrentUser as User;
                //ref User currentUser = ref Application.Current;
                //Application.Current
                //(Application.Current as App)?.CurrentUser = user;
                //currentUser = user;
                //Debug.WriteLine("set user to " + (Application.Current as App)?.CurrentUser.Username);
                Window mainWindow = (Application.Current as App)?.MainWindow as Shell;
                mainWindow = new Shell();
                mainWindow.Activate();
                Window loginWindow = (Application.Current as App)?.LoginWindow as LoginWindow;
                loginWindow.Close();

            }
            else
            {
                Debug.WriteLine("User was null");
            }
        }

        [RelayCommand]
        private void DeleteUser(UserViewModel user)
        {
            Users.Remove(user);
        }

        [RelayCommand]
        public void AddUser(object o)
        {
            Debug.WriteLine("Called Add user");
            if (o != null)
            {
                Debug.WriteLine("not null");
                string username = o as string;
                Debug.WriteLine("string is " + username);
                if (username != String.Empty)
                {
                    UserViewModel user = new UserViewModel();
                    user.Username= username;
                    /*
                    var user = new User()
                    {
                        Username = username,
                    };
                    */

                    /*
                    if(context.Set<User>().AddIfNotExists(user, x => x.Username == user.Username)==null)
                    {
                        Debug.WriteLine("Error username already exists: " + user.Username);
                    }
                    else
                    {
                        context.SaveChanges();
                    }
                    */

                    var checkUser = from g in context.Users
                                    where g.Username == username
                                    select g;
                    if (checkUser.FirstOrDefault() == null)
                    {
                        Debug.WriteLine("User added: " + username);
                        //context.Users.Add(user);
                        //context.SaveChanges
                        Users.Add(user);
                    }
                    else
                    {
                        Debug.WriteLine("Error username already exists: " + username);
                    }


                    /*
                    using (context)
                    {
                        var user = new User()
                        {                            
                            Username = username,
                        };
                        Users.Add(user);                                                
                    }*/
                }
            }
        }

        [RelayCommand]
        private void ModifyName(object o)
        {
            string oldName = "fred";
            Debug.WriteLine("called modifiy name");
            if (o != null)
            {
                string newUsername = o as string;
                Debug.WriteLine("object value " + newUsername);
                if (newUsername != String.Empty)
                {
                    Debug.WriteLine("New username " + newUsername);
                    for (int i = Users.Count - 1; i >= 0; i--)
                    {
                        Debug.WriteLine("I: " + i + " Username: " + Users[i].Username);
                        if (Users[i].Username == oldName)
                        {
                            Users[i].Username = newUsername;
                            //context.User.Remove(Users[i]);
                            //Users.RemoveAt(i);
                            Debug.WriteLine("Modified " + oldName + " is now " + newUsername);
                            // or
                            // context.Add<Student>(std);

                            context.SaveChanges();
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("Textbox empty");
                }
            }
        }


        public void UpdateUsers(List<User> users)
        {
            Users.Clear();
            Debug.WriteLine("TTotal users: " + users.Count);
            UserViewModel u;
            foreach (User user in users)
            {
                u = new UserViewModel();
                u.Username = user.Username;
                Debug.WriteLine("User: " + u.Username);
                Users.Add(u);
            }
        }

        private async void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("modified collection");
            //e.Action = NotifyCollectionChangedAction.
            if (e.NewItems != null)
            {
                Debug.WriteLine("New items to add");
                foreach (UserViewModel newItem in e.NewItems)
                {
                    Debug.WriteLine("New User: Id: " + newItem.Id + " Username " + newItem.Username);
                    //ModifiedItems.Add(newItem);

                    //Add listener for each item on PropertyChanged event
                    await newItem.SaveAsync();
                    //context.Users.Add(newItem);
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
                //context.SaveChanges();
            }

            if (e.OldItems != null)
            {
                foreach (UserViewModel oldItem in e.OldItems)
                {
                    //ModifiedItems.Add(oldItem);
                    await oldItem.DeleteAsync();
                    //context.Users.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            context.SaveChanges();
        }

    }
}
