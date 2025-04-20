using CommunityToolkit.WinUI;
using Roster.App.Services;
using Roster.App.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Page
{
    public partial class WorkerCertificatePageViewModel:BaseViewModel
    {        
        public WorkerCertificateService WorkerCertificateService { get; set; }
        private WorkerService WorkerService { get; set; }
        private CertificateService CertificateService { get; set; }

        public ObservableCollection<WorkerCertificateViewModel> WorkerCertificates { get; set; }
        public ObservableCollection<WorkerViewModel> Workers { get; set; }        
        public ObservableCollection<CertificateViewModel> Certificates { get; set; }
                

        public WorkerCertificatePageViewModel()
        {
            Debug.WriteLine("-- WorkerCertificateViewModel Constructor--");

            WorkerCertificates = new ObservableCollection<WorkerCertificateViewModel>();
            Workers = new ObservableCollection<WorkerViewModel>();
            Certificates = new ObservableCollection<CertificateViewModel>();

            WorkerCertificateService = new WorkerCertificateService(new RosterDBContext());
            WorkerService = new WorkerService(new RosterDBContext());
            CertificateService = new CertificateService(new RosterDBContext());

            GetWorkerCertificatesListAsync();
            GetWorkersListAsync();            
            GetCertificatesListAsync();

        }

        /// <summary>
        /// Saves shift to database 
        /// </summary>
        public async Task AddUpdateWorkerCertificateToDB(WorkerCertificateViewModel workerCertificate)
        {
            Debug.WriteLine("-- AddUpdateWorkerCertificateToDb --");
            await workerCertificate.AddUpdate(WorkerCertificateService);
        }

        public async Task<bool> WorkerCertificateExists(WorkerCertificateViewModel workerCertificate)
        {
            Debug.WriteLine("-- WorkerCertificateExists --");
            await workerCertificate.CheckExists(WorkerCertificateService);
            return true;
        }

        public async Task GetWorkerCertificatesListAsync()
        {
            Debug.WriteLine("-- Get Worker Certificates List Async --");
            //(CommunityToolkit.Helpers)
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var workerCertificates = await WorkerCertificateService.GetAll();

            Debug.WriteLine("Total worker certificates: " + workerCertificates.Count);

            await dispatcherQueue.EnqueueAsync(() =>
            {
                WorkerCertificates.Clear();

                foreach (var wc in workerCertificates)
                {
                    AddressViewModel workerAddress = null;
                    if (wc.Worker.Address != null)
                    {
                        workerAddress = new AddressViewModel(wc.Worker.Address.Id, wc.Worker.Address.Name, wc.Worker.Address.UnitNum, wc.Worker.Address.StreetNum, wc.Worker.Address.StreetName,
                        wc.Worker.Address.StreetType, wc.Worker.Address.Suburb, wc.Worker.Address.City);
                    }
                    Debug.WriteLine("wc id is " + wc.Worker.Id);

                   WorkerViewModel worker = new WorkerViewModel(wc.Worker.Id, wc.Worker.FirstName, wc.Worker.MiddleName, wc.Worker.LastName, wc.Worker.Nickname, wc.Worker.Gender, wc.Worker.DateOfBirth, 
                        wc.Worker.Phone, wc.Worker.Email, wc.Worker.HighlightColor, workerAddress);
                    Debug.WriteLine("worker id is " + worker.Id);
                    CertificateViewModel certificate = new CertificateViewModel(wc.Certificate.Id, wc.Certificate.Name, wc.Certificate.Description, 
                        wc.Certificate.Duration, wc.Certificate.Infinite, wc.Certificate.Required);
                    Debug.WriteLine("cert name: " + certificate.Name);

                    /*ClientViewModel client = new ClientViewModel(c.Client.Id, c.Client.FirstName, c.Client.MiddleName, c.Client.LastName, c.Client.Nickname, c.Client.Gender,
                        c.Client.DateOfBirth, c.Client.Phone, c.Client.Email, c.Client.HighlightColor, ClientAddress, c.Client.NDISNumber, c.Client.RiskCategory, c.Client.GenderPreference);*/
                    WorkerCertificateViewModel workerCertificateViewModel = new WorkerCertificateViewModel(worker, certificate, wc.DateObtained, wc.ExpiryDate);
                    if (worker != null) 
                    {
                        Debug.WriteLine("worker name " + workerCertificateViewModel.Worker.FirstName);
                    }
                    else
                    {
                        Debug.WriteLine("worker was null");
                    }

                    if (workerCertificateViewModel.Certificate != null)
                    { 
                        Debug.WriteLine("Certificate Not null: Id " + workerCertificateViewModel.Certificate.Id + " name " + workerCertificateViewModel.Certificate.Name);
                        WorkerCertificates.Add(workerCertificateViewModel);                        
                    }
                    else
                    {
                        Debug.WriteLine("Certificate Was null");
                    }
                }
                Debug.WriteLine("Total worker certificates after: " + workerCertificates.Count);
                IsLoading = false;
            });
        }

        public async Task GetCertificatesListAsync()
        {
            Debug.WriteLine("-- Get Certificates List Async --");
            //(CommunityToolkit.Helpers)
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var certificates = await CertificateService.GetAll();

            Debug.WriteLine("Total certificates: " + certificates.Count);

            await dispatcherQueue.EnqueueAsync(() =>
            {
                Certificates.Clear();

                foreach (var c in certificates)
                {
                    Debug.WriteLine("adding Id: + " + c.Id + " Name: " + c.Name);                                       
                    CertificateViewModel certificateViewModel = new CertificateViewModel(c.Id, c.Name, c.Description, c.Duration, c.Infinite, c.Required);
                    if (certificateViewModel.Name != null)
                    {
                        Debug.WriteLine("Not null: Id" + certificateViewModel.Id);
                        Certificates.Add(certificateViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total certificates after: " + certificates.Count);
                IsLoading = false;
            });
        }

        public async Task GetWorkersListAsync()
        {
            Debug.WriteLine("-- Get Workers List Async --");

            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var workers = await WorkerService.GetAll(false);

            Debug.WriteLine("Total workers: " + workers.Count);

            await dispatcherQueue.EnqueueAsync(() =>
            {
                Workers.Clear();

                foreach (var c in workers)
                {
                    Debug.WriteLine("adding Id: + " + c.Id + " Name: " + c.FirstName);
                    //AddressViewModel aVM = new AddressViewModel(c.Address.Name, c.Address.UnitNum, c.Address.StreetNum, c.Address.StreetName, c.Address.StreetType, c.Address.Suburb, "Paris");
                    WorkerViewModel workerViewModel = new WorkerViewModel(c.Id, c.FirstName, c.MiddleName, c.LastName, c.Nickname, c.Gender, c.DateOfBirth, c.Phone, c.Email, c.HighlightColor, null);
                    if (workerViewModel.FirstName != null)
                    {
                        Debug.WriteLine("Not null: Id" + workerViewModel.Id);
                        Workers.Add(workerViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total workers after: " + Workers.Count);
                IsLoading = false;
            });
        }                
    }
}
