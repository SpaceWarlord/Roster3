using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels
{
    public partial class WorkerCertificateViewModel:BaseViewModel
    {
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Worker is Required")]
        private WorkerViewModel _worker;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Certificate is Required")]
        private CertificateViewModel _certificate;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Date Obtained is Required")]
        private DateOnly _dateObtained;

        public WorkerCertificateViewModel(WorkerViewModel worker, CertificateViewModel certificate, DateOnly dateObtained)
        {
            Worker = worker;
            Certificate = certificate;
            DateObtained = dateObtained;
        }
    }
}
