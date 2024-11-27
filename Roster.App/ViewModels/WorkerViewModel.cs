using CommunityToolkit.Mvvm.ComponentModel;
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
        public int WorkerId { get; protected set; }

#nullable enable

        [ObservableProperty]
        private List<CertificateViewModel> _certificates;


        public WorkerViewModel() : base(string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }

        //bool hasManualHandlingCert = true;

        public WorkerViewModel(string firstName, string lastName, string nickname, string gender, string dob, string phone, string email, Color highlightColor) : base(firstName, lastName, nickname, gender, dob, phone, email, highlightColor)
        {

        }
    }
}
