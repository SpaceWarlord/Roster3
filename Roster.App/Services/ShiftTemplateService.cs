using Microsoft.EntityFrameworkCore;
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
    public class ShiftTemplateService
    {
        private readonly RosterDBContext _db;
        public ShiftTemplateService(RosterDBContext db)
        {
            _db = db;
        }

        public async Task<List<ShiftTemplateDTO>> GetAll()
        {
            return await _db.ShiftTemplates.Select(st => new ShiftTemplateDTO(st.Id, st.Name, new WorkerDTO(st.Worker), new ClientDTO(st.Client), st.StartTime, st.EndTime)).ToListAsync();
        }

        public async Task<bool> AddUpdate(ShiftTemplateDTO shiftTemplate)
        {
            Debug.WriteLine("-- AddUpdate --");
            Debug.WriteLine(shiftTemplate.ToString());
            var found = await _db.ShiftTemplates.FirstOrDefaultAsync(x => x.Id == shiftTemplate.Id);
            if (found is null) // new shift template
            {
                Debug.WriteLine("New shift template");                
                var w = new ShiftTemplate()
                {
                    Id = shiftTemplate.Id,
                    Name = shiftTemplate.Name,
                    StartTime = shiftTemplate.StartTime.ToString(),
                    EndTime = shiftTemplate.EndTime.ToString()
                };
                _db.ShiftTemplates.Add(w);
                return (await _db.SaveChangesAsync()) > 0;
            }
            else
            {
                Debug.WriteLine("Existing shift template");                
                found.Name = shiftTemplate.Name;
                found.StartTime = shiftTemplate.StartTime;
                found.EndTime = shiftTemplate.EndTime;

                return (await _db.SaveChangesAsync()) > 0;
            }
        }        
    }
}