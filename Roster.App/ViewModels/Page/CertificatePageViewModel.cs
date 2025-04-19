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
    public class CertificatePageViewModel:BaseViewModel
    {
        private CertificateService CertificateService { get; set; }
        public ObservableCollection<CertificateViewModel> Certificates;        

        public CertificatePageViewModel()
        {
            Debug.WriteLine("-- CertificatePageViewModel Constructor--");
            Certificates = new ObservableCollection<CertificateViewModel>();            
            CertificateService = new CertificateService(new RosterDBContext());

            GetCertificatesListAsync();
        }

        public async Task AddUpdateCertificateToDB(CertificateViewModel certificate)
        {
            Debug.WriteLine("--AddUpdateCertificateToDb--");
            await certificate.AddUpdate(CertificateService);
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
                    //AddressViewModel aVM = new AddressViewModel(c.Address.Name, c.Address.UnitNum, c.Address.StreetNum, c.Address.StreetName, c.Address.StreetType, c.Address.Suburb, "Paris");
                    //AddressViewModel WorkerAddress = new AddressViewModel(c.Worker.Address.Name, c.Worker.Address.UnitNum, c.Worker.Address.StreetNum, c.Worker.Address.StreetName, c.Worker.Address.StreetType, "", "Adelaide");
                    //AddressViewModel ClientAddress = new AddressViewModel(c.Worker.Address.Name, c.Worker.Address.UnitNum, c.Worker.Address.StreetNum, c.Worker.Address.StreetName, c.Worker.Address.StreetType, "", "Adelaide");

                    /*WorkerViewModel worker = new WorkerViewModel(c.Worker.Id, c.Worker.FirstName, c.Worker.MiddleName, c.Worker.LastName, c.Worker.Nickname,
                        c.Worker.Gender, c.Worker.DateOfBirth, c.Worker.Phone, c.Worker.Email, c.Worker.HighlightColor, WorkerAddress);
                    */

                    

                    /*ClientViewModel client = new ClientViewModel(c.Client.Id, c.Client.FirstName, c.Client.MiddleName, c.Client.LastName, c.Client.Nickname, c.Client.Gender,
                        c.Client.DateOfBirth, c.Client.Phone, c.Client.Email, c.Client.HighlightColor, ClientAddress, c.Client.NDISNumber, c.Client.RiskCategory, c.Client.GenderPreference);*/
                    
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
    }
}
