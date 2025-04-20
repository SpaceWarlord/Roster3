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
            Debug.WriteLine("-- GetAll WorkerCertificateDTO --");
            List <WorkerCertificateDTO> results = new List<WorkerCertificateDTO>();
            results = await _db.WorkerCertificates.Select(wc => new WorkerCertificateDTO(new WorkerDTO(wc.Worker), new CertificateDTO(wc.Certificate), wc.DateObtained, wc.ExpiryDate)).ToListAsync();
            Debug.WriteLine("Total results " + results.Count);
            foreach (WorkerCertificateDTO dto in results)
            {
                Debug.WriteLine(dto.ToString());
            }
            return results;
            //return await _db.WorkerCertificates.Select(wc => new WorkerCertificateDTO(new WorkerDTO(wc.Worker), new CertificateDTO(wc.Certificate), wc.DateObtained, wc.ExpiryDate)).ToListAsync();
        }

        public async Task<bool> CheckExists(WorkerCertificateDTO workerCertificate)
        {
            Debug.WriteLine("-- CheckExists --");
            var found = await _db.WorkerCertificates.FirstOrDefaultAsync(x => x.WorkerId == workerCertificate.Worker.Id && x.CertificateId == workerCertificate.Certificate.Id);
            if (found is null) // new worker certificate
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> AddUpdate(WorkerCertificateDTO workerCertificate)
        {
            Debug.WriteLine("-- AddUpdate --");
            Debug.WriteLine(workerCertificate.ToString());
            if (workerCertificate.Worker == null)
            {
                Debug.WriteLine("zworker was null");
            }
            //var found = await _db.WorkerCertificates.FirstOrDefaultAsync(x => x.Worker.Id == workerCertificate.Worker.Id && x.Certificate.Id == workerCertificate.Certificate.Id);
            var found = await _db.WorkerCertificates.FirstOrDefaultAsync(x => x.WorkerId == workerCertificate.Worker.Id && x.CertificateId == workerCertificate.Certificate.Id);
            if (found is null) // new worker certificate
            {
                Debug.WriteLine("New worker certificate");                
                Worker w = WorkerViewModel.ModelFromDTO(workerCertificate.Worker);
                Debug.WriteLine("YYY ID " + w.Id + " fname " + w.FullName);
                Certificate c = CertificateViewModel.ModelFromDTO(workerCertificate.Certificate);
                Debug.WriteLine("zzgagg " + workerCertificate.Worker.ToString());
                var wc = new WorkerCertificate()
                {
                    //Worker = w,
                    //Certificate = c,
                    //WorkerId = workerCertificate.Worker.Id,
                    //CertificateId = workerCertificate.Certificate.Id,
                    WorkerId = w.Id,
                    CertificateId = c.Id,
                    //Worker = w,
                    //Certificate = c,                    
                    DateObtained = workerCertificate.DateObtained,
                    ExpiryDate = workerCertificate.ExpiryDate,
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
