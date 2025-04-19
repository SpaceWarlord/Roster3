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
        private string? _description;

        [ObservableProperty]
        //[NotifyDataErrorInfo]
        //[Required(ErrorMessage = "Certificate Expiry Length is Required")]
        private int? _duration;


        [ObservableProperty]
        //[NotifyDataErrorInfo]
        //[Required(ErrorMessage = "Certificate Infinite Status is Required")]
        private bool _infinite;

        [ObservableProperty]
        private bool _required;

        public CertificateViewModel() //Needed for SyncFusion
        {
            Id= Guid.NewGuid().ToString();
        }

        public CertificateViewModel(string id, string name, string? description, int? duration, bool infinite, bool required)
        {
            Id = id;
            Name = name;
            Description = description;            
            Duration = duration;
            Infinite = infinite;
            Required = required;
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

        public static Certificate ModelFromDTO(CertificateDTO dto)
        {
            Certificate certificate = new Certificate()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Duration = dto.Duration,
                Infinite = dto.Infinite,
                Required = dto.Required,
            };
            return certificate;
        }

        public override T ToDTO<T>()
        {
            return (T)Convert.ChangeType(new CertificateDTO(Id, Name, Description, Duration, Infinite, Required), typeof(T));
        }

        public override T ToModel<T>()
        {
            Certificate c = new Certificate()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Duration = Duration,
                Infinite = Infinite,
                Required = Required
            };
            return (T)Convert.ChangeType(c, typeof(T));
        }
    }
}
