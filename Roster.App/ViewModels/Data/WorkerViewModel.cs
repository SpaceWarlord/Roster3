using CommunityToolkit.Mvvm.ComponentModel;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels
{
    public partial class WorkerViewModel : PersonViewModel
    {


        //protected override Person _model => throw new NotImplementedException();

#nullable enable

        /*
        [ObservableProperty]
        private List<CertificateViewModel>? _certificates = new List<CertificateViewModel>();
        */

        /*
        public WorkerViewModel() : base(string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }
        */
        //bool hasManualHandlingCert = true;

        //public WorkerViewModel(string id, string firstName, string middleName, string lastName, string nickname, string gender, string dateOfBirth, string phone, string email, Color highlightColor, List<CertificateViewModel>? certificates)
        public WorkerViewModel(string id, string firstName, string middleName, string lastName, string nickname, string gender, string dateOfBirth, string phone, string email, Color highlightColor)
            : base(id, firstName, middleName, lastName, nickname, gender, dateOfBirth, phone, email, highlightColor)
        {
            //Certificates = certificates;            
        }

        public override T ToDTO<T>()
        {
            //throw new NotImplementedException();
            return null;
        }
    }
}