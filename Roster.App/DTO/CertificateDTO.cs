using Roster.App.ViewModels.Data;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace Roster.App.DTO
{
    public class CertificateDTO:BaseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Duration { get; set; }
        public bool Infinite { get; set; }
        public bool Required { get; set; }
        public CertificateDTO(string id, string name, string description, int? duration, bool infinite, bool required) 
        {
            Id = id;
            Name = name;
            Description = description;
            Duration = duration;
            Infinite = infinite;
            Required = required;
        }

        public CertificateDTO(Certificate certificate)
        {
            if (certificate != null)
            {
                Id = certificate.Id;
                Name = certificate.Name;
                Description = certificate.Description;
                Duration = certificate.Duration;
                Infinite = certificate.Infinite;
                Required = certificate.Required;
            }
            else
            {
                Debug.WriteLine("Certificate was null");
            }
        }

        public CertificateDTO(CertificateViewModel certificate)
        {
            if (certificate != null)
            {
                Id = certificate.Id;
                Name = certificate.Name;
                Description = certificate.Description;
                Duration = certificate.Duration;
                Infinite = certificate.Infinite;
                Required = certificate.Required;                
            }
            else
            {
                Debug.WriteLine("CertificateViewModel was null");
            }
        }
    }
}
