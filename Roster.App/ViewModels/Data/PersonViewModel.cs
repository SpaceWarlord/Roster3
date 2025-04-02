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
using Roster.App.ViewModels.Data;
using System.Diagnostics.CodeAnalysis;

namespace Roster.App.ViewModels
{
    public abstract partial class PersonViewModel: DataViewModel
    {        

        /// <summary>
        /// Gets or sets the person's ID.
        /// </summary>

        [ObservableProperty]
        private string _id;

        /// <summary>
        /// Gets or sets the person's first name.
        /// </summary>

        [ObservableProperty]
        private string _firstName;


        /// <summary>
        /// Gets or sets the person's middle name.
        /// </summary>

        [ObservableProperty]
        private string? _middleName;

        /// <summary>
        /// Gets or sets the person's last name.
        /// </summary>

        [ObservableProperty]
        private string _lastName;        

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

        [NotMapped]
        public static string[] GenderTypes = ["M", "F"];
        



        /// <summary>
        /// Gets or sets the person's nickname.
        /// </summary>

        [ObservableProperty]
        [NotNull]
        private string _nickname;


        /// <summary>
        /// Gets or sets the person's gender.
        /// </summary>

        [ObservableProperty]
        private string? _gender;

        /// <summary>
        /// Gets or sets the person's date of birth.
        /// </summary>

        [ObservableProperty]
        private string? _dateOfBirth;


        /// <summary>
        /// Gets or sets the person's phone.
        /// </summary>

        [ObservableProperty]
        private string? _phone;

        /// <summary>
        /// Gets or sets the person's email.
        /// </summary>

        [ObservableProperty]
        private string? _email;

        /// <summary>
        /// Gets or sets the person's highlight color.
        /// </summary>

        [ObservableProperty]
        private string? _highlightColor;

        /// <summary>
        /// Gets or sets the person's address.
        /// </summary>


        [ObservableProperty]
        private AddressViewModel? _address;             

        public PersonViewModel():base()
        {
            Debug.WriteLine("-- PersonViewModel Constructor Blank--");
            Id = Guid.NewGuid().ToString();
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Nickname = "";
            Gender = "M";
            DateOfBirth = "";
        }        

        public PersonViewModel(PersonViewModel person):base()
        {
            Debug.WriteLine("-- PersonViewModel Constructor with param--");
            if (person != null)
            {
                Id = person.Id;
                FirstName = person.FirstName;
                MiddleName = person.MiddleName;
                LastName = person.LastName;
                Nickname = person.Nickname;
                Gender = person.Gender;
                DateOfBirth = person.DateOfBirth;
            }
            else
            {
                Id = Guid.NewGuid().ToString();
                FirstName = "";
                MiddleName = "";
                LastName = "";
                Nickname = "";
                Gender = "M";
                DateOfBirth = "";
            }                        
        }

        public PersonViewModel(string id, string firstName, string? middleName, string lastName, string nickname, string? gender, string? dateOfBirth, string? phone, string? email, string? highlightColor, AddressViewModel? address):base()
        {
            Debug.WriteLine("--PersonViewModel Constructor 1--");     
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor;
            Address = address;
        }

        public PersonViewModel(string id, string firstName, string? middleName, string lastName, string nickname, string? gender, string? dateOfBirth, string? phone, string? email, Color? highlightColor)
        {
            Debug.WriteLine("--PersonViewModel Constructor 2--");
                  
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            if (highlightColor == null) //https://stackoverflow.com/questions/4454336/can-i-specify-a-default-color-parameter-in-c-sharp-4-0
            {
                highlightColor = Color.Black;
            }
            HighlightColor = highlightColor.ToString();
            //_userId = userId;
        }
    }
}
