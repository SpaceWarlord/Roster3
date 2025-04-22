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
    public class ObjectiveService:BaseService
    {
        private readonly RosterDBContext _db;
        public ObjectiveService(RosterDBContext db)
        {
            _db = db;
        }

        public async Task<List<ObjectiveDTO>> GetAll()
        {
            return await _db.Objectives.Select(o => new ObjectiveDTO(o.Id, o.Name, o.Description, o.PriorityRating, o.DateAdded, o.CompleteBy, o.Completed, 
                new WorkerDTO(o.Worker), new ClientDTO(o.Client))).ToListAsync();
        }

        public async Task<bool> AddUpdate(ObjectiveDTO objective)
        {
            Debug.WriteLine("-- AddUpdate --");
            Debug.WriteLine(objective.ToString());
            var found = await _db.Objectives.FirstOrDefaultAsync(x => x.Id == objective.Id);
            if (found is null) // new objective
            {
                Debug.WriteLine("New Objective");
                Client c = ClientViewModel.ModelFromDTO(objective.Client);
                Worker w = WorkerViewModel.ModelFromDTO(objective.Worker);

                Debug.WriteLine("zWorker= " + objective.Worker.ToString());
                var o = new Objective()
                {
                    Id = objective.Id,
                    Name = objective.Name,
                    Description = objective.Description,
                    PriorityRating = objective.PriorityRating,
                    DateAdded = objective.DateAdded,
                    CompleteBy = objective.CompleteBy,
                    Completed = objective.Completed,
                    WorkerId = w.Id,
                    ClientId = c.Id,
                    Category = "1",
                };
                _db.Objectives.Add(o);

                return (await _db.SaveChangesAsync()) > 0;
            }
            else
            {
                Debug.WriteLine("Existing objective");
                found.Name = objective.Name;
                found.Description = objective.Description;
                found.PriorityRating = objective.PriorityRating;
                found.DateAdded = objective.DateAdded;
                found.CompleteBy = objective.CompleteBy;
                found.Completed = objective.Completed;
                found.WorkerId = objective.Worker.Id;
                found.ClientId = objective.Client.Id;
                found.Category = "1";
                return (await _db.SaveChangesAsync()) > 0;
            }
        }
    }
}
