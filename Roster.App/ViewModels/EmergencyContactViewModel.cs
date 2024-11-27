using CommunityToolkit.Mvvm.ComponentModel;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels
{
    public partial class EmergencyContactViewModel:PersonViewModel
    {
        [ObservableProperty]
        private Person _contactFor;
        public EmergencyContactViewModel(string firstName, string lastName, string nickname, string gender, Person contactFor) : base(firstName, lastName, nickname, gender)
        {
            _contactFor = contactFor;
        }
    }
}
