using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Helpers;
using CommunityToolkit.WinUI;
using Roster.App.Helpers;
using Roster.App.Main;
using Roster.Models;
using Roster.App.Services;
using Roster.App.DTO;
using Roster.App.ViewModels.Data;



namespace Roster.App.ViewModels.Page
{
    public partial class LoginPageViewModel:BaseViewModel
    {
        public ObservableCollection<UserViewModel> Users;

        public UserService UserService { get; set; }
        public UserViewModel NewUser { get; set; }
        public LoginPageViewModel() 
        {
            UserService = new UserService(new RosterDBContext());
            Users = new ObservableCollection<UserViewModel>();
            NewUser = new UserViewModel("", "");
            //Users.CollectionChanged += this.OnCollectionChanged;
            //Task.Run(GetUsersListAsync);
            //dispatcherQueue.EnqueueAsync
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


        /*
        [RelayCommand]
        private void DeleteUser(UserViewModel user)
        {
            Debug.WriteLine("called delete user");
            Debug.WriteLine("username: " + user.Username);
            Users.Remove(user);
        }
        */

        /// <summary>
        /// Deletes user from database, then refreshes user list
        /// </summary>

        [RelayCommand]
        private async Task DeleteUser(UserViewModel user)
        {
            Debug.WriteLine("Called delete user");
            await user.DeleteAsync();
            await GetAll();

            //Users.Remove(user);
        }

        [RelayCommand]
        public async Task AddUser(object o)
        {
            Debug.WriteLine("Called Add user");
            if (o != null)
            {
                Debug.WriteLine("not null");
                string? username = o as string;
                Debug.WriteLine("string is " + username);
                if (!string.IsNullOrWhiteSpace(username))
                {
                    UserViewModel user = new UserViewModel(Guid.NewGuid().ToString(), username);
                    Users.Clear();
                    List<UserDTO> userDTOList = await UserService.GetAll();
                    foreach (UserDTO userDTO in userDTOList)
                    {
                        Users.Add(new UserViewModel(userDTO.Id, userDTO.Username));
                    }
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

                    /*
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
                    */

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
                else
                {
                    Debug.WriteLine("Username was empty or blank");
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

                            //context.SaveChanges();
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
                u = new UserViewModel(user.Id, user.Username);
                u.Username = user.Username;
                Debug.WriteLine("User: " + u.Username);
                Users.Add(u);
            }
        }


        /// <summary>
        /// Saves user to database then clears fields 
        /// </summary>
        public async Task AddUserToDB()
        {
            Debug.WriteLine("--AddUserToDb--");
            NewUser.Id = Guid.NewGuid().ToString();
            await NewUser.SaveAsync(UserService);
            NewUser = new("","");
            await GetAll();
        }               
        
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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
                    //await newItem.SaveAsync();
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
                    //await oldItem.DeleteAsync();
                    //context.Users.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            //context.SaveChanges();
        }

        public async Task GetAll()
        {
            List<UserDTO> userDTOList = await UserService.GetAll();
            Debug.WriteLine("Total users found: " + userDTOList.Count);
            /*
            List<TestViewModel> tList = TestViewModel.ToViewModelList(testDTOList);
            Tests = new ObservableCollection<TestViewModel>(tList as List<TestViewModel>);
            */

            Users.Clear();
            foreach (UserDTO userDTO in userDTOList)
            {
                Debug.WriteLine("Adding: " + userDTO.Id + " username: " + userDTO.Username);
                Users.Add(new UserViewModel(userDTO.Id, userDTO.Username));
                
            }
        }

        /// <summary>
        /// Gets the complete list of customers from the database.
        /// </summary>
        //public void GetUsersListAsync()

        /*
        public async Task GetUsersListAsync()
        {
            Debug.WriteLine("-- Get Users List Async --");
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            //var users = await App.Repository.Users.GetAsync();            
            var users = UserService.GetAll();
            if (users == null)
            {
                Debug.WriteLine("users was null");
                return;
            }
            Debug.WriteLine("Total users:" + users.Count);
                       
            await dispatcherQueue.EnqueueAsync(() =>
            {
                Users.Clear();
                
                foreach (var u in users)
                {
                    Debug.WriteLine("adding " + u.Username);                    
                    UserViewModel userViewModel = new UserViewModel(u);
                    if (userViewModel.Username != null)
                    {
                        Debug.WriteLine("Not null: Id" + userViewModel.Id + " name: " + userViewModel.Username);
                        Users.Add(userViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }                                        
                }                
                IsLoading = false;               
            });            
        }
        */
    }
}