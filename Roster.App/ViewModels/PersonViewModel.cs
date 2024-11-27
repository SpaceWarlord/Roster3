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
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the person's first name.
        /// </summary>

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

        [NotMapped]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }

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

        public PersonViewModel(Person person)
        {            
            FirstName = person.FirstName;
            LastName = person.LastName;
            Nickname = person.Nickname;
            Gender = person.Gender;
        }

        public PersonViewModel(string firstName, string lastName, string nickname, string gender)
        {
            Debug.WriteLine("Adding person");

            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
        }

        public PersonViewModel(string firstName, string lastName, string nickname, string gender, string dob, string phone, string email, Color? highlightColor)
        {
            if (highlightColor == null) //https://stackoverflow.com/questions/4454336/can-i-specify-a-default-color-parameter-in-c-sharp-4-0
            {
                highlightColor = Color.Black;
            }

            Debug.WriteLine("Adding person");

            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            Dob = dob;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor.ToString();
            //_userId = userId;
        }
    }
}
