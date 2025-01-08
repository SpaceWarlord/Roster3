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

        
        public EmergencyContactViewModel(string firstName, string lastName, string nickname, string gender, string? dob, string? phone, string? email, string? highlightColor, Address? address, Person contactFor) 
            : base(firstName, lastName, nickname, gender, dob, phone, email, highlightColor, address)
        {
            _contactFor = contactFor;
        }
        

        //protected override Person _model => throw new NotImplementedException();
    }
}
