using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.DTO
{
    public class WorkerCertificateDTO: BaseDTO
    {
        public WorkerDTO Worker { get; set; }
        public CertificateDTO Certificate { get; set; }
        public DateTimeOffset DateObtained { get; set; }
        public DateTimeOffset ExpiryDate { get; set; }
        public WorkerCertificateDTO(WorkerDTO worker, CertificateDTO certificate, DateTimeOffset dateObtained, DateTimeOffset expiryDate) 
        { 

        }
    }
}
