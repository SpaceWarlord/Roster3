using CommunityToolkit.Mvvm.ComponentModel;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using System.Drawing;
using System.Reflection;

namespace Roster.App.ViewModels
{
    public abstract partial class PersonViewModel: BaseViewModel
    {
       protected abstract Person _model { get; }

        /// <summary>
        /// Gets or sets the person's ID.
        /// </summary>
        public int Id
        {
            get => _model.Id;
            set
            {
                if (value != _model.Id)
                {
                    _model.Id = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the person's first name.
        /// </summary>

        public string FirstName
        {
            get => _model.FirstName;
            set
            {
                if (value != _model.FirstName)
                {
                    Debug.WriteLine("name set to: " + value);
                    _model.FirstName = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the person's last name.
        /// </summary>

        public string LastName
        {
            get => _model.LastName;
            set
            {
                if (value != _model.LastName)
                {
                    _model.LastName = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

#nullable enable

        /// <summary>
        /// Gets or sets the person's full name.
        /// </summary>

        [NotMapped]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }

        /// <summary>
        /// Gets or sets the person's nickname.
        /// </summary>

        public string Nickname
        {
            get => _model.Nickname;
            set
            {
                if (value != _model.Nickname)
                {
                    _model.Nickname = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the person's gender.
        /// </summary>

        public string Gender
        {
            get => _model.Gender;
            set
            {
                if (value != _model.Gender)
                {
                    _model.Gender = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the person's date of birth.
        /// </summary>

        public string? DOB
        {
            get => _model.DOB;
            set
            {
                if (value != _model.DOB)
                {
                    _model.DOB = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the person's phone.
        /// </summary>

        public string? Phone
        {
            get => _model.Phone;
            set
            {
                if (value != _model.Phone)
                {
                    _model.Phone = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the person's email.
        /// </summary>

        public string? Email
        {
            get => _model.Email;
            set
            {
                if (value != _model.Email)
                {
                    _model.Email = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the person's highlight color.
        /// </summary>


        public string? HighlightColor
        {
            get => _model.HighlightColor;
            set
            {
                if (value != _model.HighlightColor)
                {
                    _model.HighlightColor = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the person's address.
        /// </summary>

        public Address? Address
        {
            get => _model.Address;
            set
            {
                if (value != _model.Address)
                {
                    _model.Address = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }


        /*      
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(FullName))]
        [Required(ErrorMessage = "First Name is Required")]
        private string _firstName;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(FullName))]
        [Required(ErrorMessage = "Last Name is Required")]
        private string _lastName;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Nickname is Required")]
        private string _nickname;

        
        

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Gender is requred")]
        private string _gender;

        [ObservableProperty]
        private string? _dob;

#nullable enable
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Phone]
        private string? _phone;

#nullable enable
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [EmailAddress]
        private string? _email;

        [ForeignKey("AddressId")] // for a shadow property to the Address ID FK
        public virtual Address Address { get; set; }

        [ObservableProperty]
        private string? _highlightColor;

        */

        public PersonViewModel()
        {
            Debug.WriteLine("-- PersonViewModel Constructor Blank--");
            //_model = new PersonViewModel();
            /*
            FirstName = string.Empty;
            LastName = string.Empty;
            Nickname = string.Empty;
            Gender = string.Empty;
            */
        }
        public PersonViewModel(PersonViewModel person)
        {
            Debug.WriteLine("-- PersonViewModel Constructor with param--");
            if (person != null)
            {
                //_model = person._model;
            }
            else
            {                
                //_model= new Person();
            }
            
            /*
            FirstName = person.FirstName;
            LastName = person.LastName;
            Nickname = person.Nickname;
            Gender = person.Gender;
            */
        }

        public PersonViewModel(string firstName, string lastName, string nickname, string gender, string? dob, string? phone, string? email, string? highlightColor, Address? address)
        {
            Debug.WriteLine("--PersonViewModel Constructor 1--");            
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            DOB = dob;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor;
            Address = address;
        }

        public PersonViewModel(string firstName, string lastName, string nickname, string gender, string dob, string phone, string email, Color? highlightColor)
        {
            Debug.WriteLine("--PersonViewModel Constructor 2--");
            if (highlightColor == null) //https://stackoverflow.com/questions/4454336/can-i-specify-a-default-color-parameter-in-c-sharp-4-0
            {
                highlightColor = Color.Black;
            }            

            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            DOB = dob;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor.ToString();
            //_userId = userId;
        }
    }
}
