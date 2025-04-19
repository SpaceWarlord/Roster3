using Microsoft.EntityFrameworkCore;
using Roster.App.DTO;
using Roster.App.ViewModels.Data;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.Services
{
    public class WorkerCertificateService: BaseService
    {
        private readonly RosterDBContext _db;
        public WorkerCertificateService(RosterDBContext db)
        {
            _db = db;
        }

        public async Task<List<WorkerCertificateDTO>> GetAll()
        {
            return await _db.WorkerCertificates.Select(wc => new WorkerCertificateDTO(new WorkerDTO(wc.Worker), new CertificateDTO(wc.Certificate), wc.DateObtained, wc.ExpiryDate)).ToListAsync();
        }

        public async Task<bool> AddUpdate(WorkerCertificateDTO workerCertificate)
        {
            Debug.WriteLine("-- AddUpdate --");
            Debug.WriteLine(workerCertificate.ToString());
            if (workerCertificate.Worker == null)
            {
                Debug.WriteLine("zworker was null");
            }
            var found = await _db.WorkerCertificates.FirstOrDefaultAsync(x => x.Worker.Id == workerCertificate.Worker.Id && x.Certificate.Id == workerCertificate.Certificate.Id);
            if (found is null) // new worker certificate
            {
                Debug.WriteLine("New worker certificate");                
                Worker w = WorkerViewModel.ModelFromDTO(workerCertificate.Worker);
                Certificate c = CertificateViewModel.ModelFromDTO(workerCertificate.Certificate);
                Debug.WriteLine("zzgagg " + workerCertificate.Worker.ToString());
                var wc = new WorkerCertificate()
                {                    
                    WorkerId = w.Id,
                    CertificateId = w.Id,
                };
                _db.WorkerCertificates.Add(wc);

                return (await _db.SaveChangesAsync()) > 0;
            }
            else
            {
                Debug.WriteLine("Existing worker certificate");
                
                found.WorkerId = workerCertificate.Worker.Id;
                found.CertificateId = workerCertificate.Certificate.Id;


                return (await _db.SaveChangesAsync()) > 0;
            }
        }
    }
}
