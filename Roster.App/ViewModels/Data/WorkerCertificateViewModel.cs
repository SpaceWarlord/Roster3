using CommunityToolkit.Mvvm.ComponentModel;
using Roster.App.DTO;
using Roster.App.Services;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Roster.App.ViewModels.Data
{
    public partial class WorkerCertificateViewModel: DataViewModel
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
        private DateTimeOffset _dateObtained;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Expiry Date is Required")]
        private DateTimeOffset _expiryDate;

        public WorkerCertificateViewModel() //needed for syncfusion
        {
            
        }

        public WorkerCertificateViewModel(WorkerViewModel worker, CertificateViewModel certificate, DateTimeOffset dateObtained, DateTimeOffset expiryDate)
        {
            Worker = worker;
            Certificate = certificate;
            DateObtained = dateObtained;
            ExpiryDate = expiryDate;
        }

        public async Task AddUpdate(WorkerCertificateService workerCertificateService)
        {
            Debug.WriteLine("Called Save Async");
            IsModified = false;
            if (IsNew)
            {
                Debug.WriteLine("its new");
                IsNew = false;
                if (Worker == null)
                {
                    Debug.WriteLine("Worker was null");
                }
                else
                {
                    Debug.WriteLine("Worker not null");
                    Debug.WriteLine("Id is " + Worker.Id);
                }
                WorkerCertificateDTO wc = ToDTO<WorkerCertificateDTO>();
                if (wc.Worker == null)
                {
                    Debug.WriteLine("BINGO");
                }
                await workerCertificateService.AddUpdate(ToDTO<WorkerCertificateDTO>());
            }
        }

        public async Task<bool> CheckExists(WorkerCertificateService workerCertificateService)
        {
            Debug.WriteLine("-- Check Exists --");
            return await workerCertificateService.CheckExists(ToDTO<WorkerCertificateDTO>());
        }

        public override T ToDTO<T>()
        {
            Debug.WriteLine("-- ToDTO --");
            WorkerDTO worker = new WorkerDTO(Worker);
            if (worker == null)
            {
                Debug.WriteLine("Worker was null");
            }
            CertificateDTO certificate = new CertificateDTO(Certificate);
            if (certificate == null)
            {
                Debug.WriteLine("Certificate was null");
            }
            WorkerCertificateDTO dto = (T)Convert.ChangeType(new WorkerCertificateDTO(worker, certificate, DateObtained, ExpiryDate), typeof(T)) as WorkerCertificateDTO;
            if (dto==null)
            {
                Debug.WriteLine("dto was null");
            }
            else
            {
                Debug.WriteLine("dto was not null");
                if(dto.Worker == null)
                {
                    Debug.WriteLine("ttworker was null");
                }
                if (dto.Certificate == null)
                {
                    Debug.WriteLine("ttcertificate was null");
                }
            }
                return (T)Convert.ChangeType(new WorkerCertificateDTO(worker, certificate, DateObtained, ExpiryDate), typeof(T));
        }

        public override T ToModel<T>()
        {
            //Worker w = Worker.ToModel<Worker>();

            WorkerCertificate wc = new WorkerCertificate()
            {
                Worker = Worker.ToModel<Worker>(),
                Certificate = Certificate.ToModel<Certificate>(),
                DateObtained = DateObtained,
                ExpiryDate = ExpiryDate
            };
            return (T)Convert.ChangeType(wc, typeof(T));
        }
    }
}
