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

        
        public EmergencyContactViewModel(string id, string firstName, string middleName, string lastName, string nickname, string gender, string? dateOfBirth, string? phone, string? email, string? highlightColor, AddressViewModel? address, Person contactFor) 
            : base(id, firstName, middleName, lastName, nickname, gender, dateOfBirth, phone, email, highlightColor, address)
        {
            _contactFor = contactFor;
        }

        public override T ToDTO<T>()
        {
            throw new NotImplementedException();
        }


        //protected override Person _model => throw new NotImplementedException();
    }
}
