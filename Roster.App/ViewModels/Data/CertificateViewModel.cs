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
    public partial class CertificateViewModel: DataViewModel
    {
        [ObservableProperty]
        private string _id;

        [ObservableProperty]
        //[NotifyDataErrorInfo]
        //[Required(ErrorMessage = "Certificate is Required")]
        private string _name;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        //[NotifyDataErrorInfo]
        //[Required(ErrorMessage = "Certificate Expiry Length is Required")]
        private int _certLength;


        [ObservableProperty]
        //[NotifyDataErrorInfo]
        //[Required(ErrorMessage = "Certificate Infinite Status is Required")]
        private bool _infinite;
        public CertificateViewModel() //Needed for SyncFusion
        {
            Id= Guid.NewGuid().ToString();
        }

        public CertificateViewModel(string id, string description, string name, int certLength, bool infinite)
        {
            Id = id;
            Description = description;
            Name = name;
            CertLength = certLength;
            Infinite = infinite;
        }

        public async Task AddUpdate(CertificateService certificateService)
        {
            Debug.WriteLine("Called Save Async");
            IsModified = false;
            if (IsNew)
            {
                Debug.WriteLine("its new");
                IsNew = false;
                await certificateService.AddUpdate(ToDTO<CertificateDTO>());
            }
        }

        public override T ToDTO<T>()
        {
            return (T)Convert.ChangeType(new CertificateDTO(Id, Name, Description, CertLength, Infinite), typeof(T));
        }

        public override T ToModel<T>()
        {
            Certificate c = new Certificate()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                CertLength = CertLength,
                Infinite = Infinite                
            };
            return (T)Convert.ChangeType(c, typeof(T));
        }
    }
}
