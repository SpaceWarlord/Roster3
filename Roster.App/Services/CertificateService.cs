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
    public class CertificateService:BaseService
    {
        private readonly RosterDBContext _db;
        public CertificateService(RosterDBContext db)
        {
            _db = db;
        }

        public async Task<List<CertificateDTO>> GetAll()
        {
            return await _db.Certificates.Select(c => new CertificateDTO(c.Id, c.Name, c.Description, c.CertLength, c.Infinite)).ToListAsync();
        }

        public async Task<bool> AddUpdate(CertificateDTO certificate)
        {
            Debug.WriteLine("-- AddUpdate --");
            Debug.WriteLine(certificate.ToString());
            var found = await _db.Certificates.FirstOrDefaultAsync(x => x.Id == certificate.Id);
            if (found is null) // new certificate
            {
                Debug.WriteLine("New certificate");                               
                var c = new Certificate()
                {
                    Id = certificate.Id,
                    Name = certificate.Name,
                    Description = certificate.Description,
                    CertLength = certificate.CertLength,
                    Infinite = certificate.Infinite,
                };
                _db.Certificates.Add(c);
                return (await _db.SaveChangesAsync()) > 0;
            }
            else
            {
                Debug.WriteLine("Existing certificate");
                found.Name = certificate.Name;
                found.Description = certificate.Description;
                found.CertLength = certificate.CertLength;
                found.Infinite = certificate.Infinite;
                return (await _db.SaveChangesAsync()) > 0;
            }
        }
    }
}
