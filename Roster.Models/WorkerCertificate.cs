using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace Roster.Models
{
    //[PrimaryKey(nameof(Worker), nameof(Certificate))]
    [PrimaryKey(nameof(WorkerId), nameof(CertificateId))]
    public partial class WorkerCertificate:BaseModel
    {
        
        [ForeignKey("WorkerId")] // for a shadow property to the Address ID FK
        public Worker Worker;

        
        [ForeignKey("CertificateId")] // for a shadow property to the Address ID FK
        public Certificate Certificate {  get; set; }

        public string? WorkerId { get; set; }
        public string? CertificateId { get; set; }
        public DateTimeOffset DateObtained {  get; set; }
        public DateTimeOffset ExpiryDate { get; set; }    
        
        public WorkerCertificate()
        {

        }
    }
}