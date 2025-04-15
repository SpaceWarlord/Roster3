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
    public class TestService:BaseService
    {
        private readonly RosterDBContext _db;
        public TestService(RosterDBContext db)
        {
            _db = db;
        }

        public async Task<List<TestDTO>> GetAll()
        {
            Debug.WriteLine("--TestService GetAll --");
            return await _db.Tests.Select(st => new TestDTO(st.Id, st.Name, st.Description, st.StartDate, st.EndDate, st.StartTime, st.EndTime)).ToListAsync();
        }

        public async Task<bool> AddUpdate(TestDTO test)
        {
            Debug.WriteLine("-- AddUpdate --");
            Debug.WriteLine(test.ToString());
            var found = await _db.Tests.FirstOrDefaultAsync(x => x.Id == test.Id);
            if (found is null) // new shift template
            {
                Debug.WriteLine("New test");                                              
                Debug.WriteLine("zzgagg " + test.StartTime.ToString());
                var st = new Test()
                {
                    Id = test.Id,
                    Name = test.Name,   
                    Description = test.Description,
                    StartDate = test.StartDate,
                    EndDate = test.EndDate,
                    StartTime = test.StartTime,
                    EndTime = test.EndTime
                };
                _db.Tests.Add(st);
                return (await _db.SaveChangesAsync()) > 0;
            }
            else
            {
                Debug.WriteLine("Existing test");
                found.Name = test.Name;
                found.Description = test.Description;
                found.StartDate = test.StartDate;
                found.EndDate = test.EndDate;
                found.StartTime = test.StartTime;
                found.EndTime = test.EndTime;

                return (await _db.SaveChangesAsync()) > 0;
            }
        }
    }
}
