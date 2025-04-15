using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.UI.Xaml.Controls;
using Roster.App.DTO;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.Services
{
    public class WorkerService
    {
        private readonly RosterDBContext _db;
        public WorkerService(RosterDBContext db)
        {
            _db = db;
        }

        public async Task<List<WorkerDTO>> GetAll(bool tracking=true)
        {
            Debug.WriteLine("--Worker GetAll --");
            if (tracking)
            {
                Debug.WriteLine("Tracking");
                return await _db.Workers.Select(w => new WorkerDTO(w.Id, w.FirstName, w.MiddleName, w.LastName, w.Nickname, w.Gender, w.DateOfBirth, w.Phone, w.Email, w.HighlightColor,
                new AddressDTO(w.Address.Id, w.Address.Name, w.Address.UnitNum, w.Address.StreetNum, w.Address.StreetName, w.Address.StreetType, w.Address.SuburbId))).ToListAsync();
            }
            else
            {
                Debug.WriteLine("No Tracking");
                return await _db.Workers.AsNoTracking().Select(w => new WorkerDTO(w.Id, w.FirstName, w.MiddleName, w.LastName, w.Nickname, w.Gender, w.DateOfBirth, w.Phone, w.Email, w.HighlightColor,
                new AddressDTO(w.Address.Id, w.Address.Name, w.Address.UnitNum, w.Address.StreetNum, w.Address.StreetName, w.Address.StreetType, w.Address.SuburbId))).ToListAsync();
            }            
        }

        public async Task<bool> AddUpdate(WorkerDTO worker, bool tracking = true)
        {
            Debug.WriteLine("-- AddUpdate --");
            Debug.WriteLine(worker.ToString());
            var found = await _db.Workers.FirstOrDefaultAsync(x => x.Id == worker.Id);
            if (found is null) // new worker
            {
                Debug.WriteLine("New worker");
                var nicknameExists = await _db.Workers.FirstOrDefaultAsync(x => x.Nickname == worker.Nickname);
                if (nicknameExists is null)
                {
                    Debug.WriteLine("Adding new worker");
                    var w = new Worker()
                    {
                        Id = worker.Id,
                        FirstName = worker.FirstName,
                        MiddleName = worker.MiddleName,
                        LastName = worker.LastName,
                        Nickname = worker.Nickname,
                        Gender = worker.Gender,
                    };
                    _db.Workers.Add(w);
                    return (await _db.SaveChangesAsync()) > 0;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Debug.WriteLine("Existing worker");               
                Worker? nicknameExists = null;
                if (tracking)
                {
                    nicknameExists = await _db.Workers.FirstOrDefaultAsync(x => x.Nickname == worker.Nickname && x.Id != worker.Id);
                }
                else
                {
                    nicknameExists= await _db.Workers.AsNoTracking().FirstOrDefaultAsync(x => x.Nickname == worker.Nickname && x.Id != worker.Id);
                }
                if (nicknameExists is null)
                {
                    Debug.WriteLine("Updating existing worker");
                    found.FirstName = worker.FirstName;
                    found.MiddleName = worker.MiddleName;
                    found.LastName = worker.LastName;
                    found.Nickname = worker.Nickname;
                    found.Gender = worker.Gender;
                    return (await _db.SaveChangesAsync()) > 0;
                }
                else
                {
                    return false;
                }
            }
        }        
    }
}
