using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;



namespace Roster.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {        
        public required string Id { get; set; }

        public required string Username { get; set; }
              
        /*
        public User(Entities.User userEntity)
        {            
            Id = userEntity.Id;
           _username = userEntity.Username;
        }
        */        

                      

        /*
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    this.OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        */
        /*
        public string Username { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public User()
        {
           
        }

        
        public User(int id, string username)
        {
            Id = id;
            Username = username;
        } 
        */
        /*
        [ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(FullAddress))]
        private string userName;
        */
        /*
        public string UserName
        {
            get { return userName; }

            set
            {
                Debug.WriteLine("setting property");
                if (value != userName)
                {
                    userName = value;
                    OnPropertyChanged("changedUsername");
                }
            }
        }   
        */

        //public event PropertyChangedEventHandler PropertyChanged;

        /*
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/

        /*
        protected void OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine("prop changed " + propertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }*/
    }

    //public string UserName { get; set; }


    /*
    public class User: NotifyingEntity
    {
        public int Id { get; set; }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetWithNotify(value, out _userName);
        }

        public event PropertyChangedEventHandler PropertyChanged
        {

        }

        //public string UserName { get; set; }
    }

    //private void ABC()

    public abstract class NotifyingEntity : INotifyPropertyChanging, INotifyPropertyChanged
    {
        protected void SetWithNotify<T>(T value, out T field, [CallerMemberName] string propertyName = "")
        {
            NotifyChanging(propertyName);
            field = value;
            NotifyChanged(propertyName);
        }

        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void NotifyChanging(string propertyName)
            => PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }
    */
}
