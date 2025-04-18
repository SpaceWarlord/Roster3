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
    public class ShiftService:BaseService
    {
        private readonly RosterDBContext _db;
        public ShiftService(RosterDBContext db)
        {
            _db = db;
        }

        public async Task<List<ShiftDTO>> GetAll()
        {
            return await _db.Shifts.Select(s => new ShiftDTO(s.Id, s.Name, s.Description, s.StartDate, s.EndDate, s.StartTime, s.EndTime, new WorkerDTO(s.Worker), new ClientDTO(s.Client)
                , s.TravelTime, s.MaxTravelDistance, new AddressDTO(s.StartLocation), new AddressDTO(s.EndLocation), s.ShiftType, s.Reoccuring, s.CaseNoteCompleted)).ToListAsync();
        }

        public async Task<bool> AddUpdate(ShiftDTO shift)
        {
            Debug.WriteLine("-- AddUpdate --");
            Debug.WriteLine(shift.ToString());
            var found = await _db.Shifts.FirstOrDefaultAsync(x => x.Id == shift.Id);
            if (found is null) // new shift
            {
                Debug.WriteLine("New shift");                
                Client c = ClientViewModel.ModelFromDTO(shift.Client);                
                Worker w = WorkerViewModel.ModelFromDTO(shift.Worker);
               
                Debug.WriteLine("zzgagg " + shift.Worker.ToString());
                var s = new Shift()
                {
                    Id = shift.Id,
                    Name = shift.Name,
                    Description = shift.Description,
                    StartDate = shift.StartDate,
                    EndDate = shift.EndDate,
                    StartTime = shift.StartTime,
                    EndTime = shift.EndTime,
                    WorkerId = w.Id,
                    ClientId = c.Id,                   
                };
                _db.Shifts.Add(s);

                return (await _db.SaveChangesAsync()) > 0;
            }
            else
            {
                Debug.WriteLine("Existing shift");
                found.Name = shift.Name;
                found.Description = shift.Description;
                found.StartDate = shift.StartDate;
                found.EndDate = shift.EndDate;
                found.StartTime = shift.StartTime;
                found.EndTime = shift.EndTime;
                found.WorkerId = shift.Worker.Id;
                found.ClientId = shift.Client.Id;


                return (await _db.SaveChangesAsync()) > 0;
            }
        }
    }
}
