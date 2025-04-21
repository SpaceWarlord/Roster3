using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.DTO
{
    public class ObjectiveDTO:BaseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PriorityRating { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset CompleteBy { get; set; }
        public bool Completed { get; set; } = false;

        public WorkerDTO? Worker { get; set; }
        public ClientDTO? Client { get; set; }

        public ObjectiveDTO(string id, string name, string description, string priorityRating, DateTimeOffset dateAdded, DateTimeOffset completedBy, bool completed, WorkerDTO? worker, ClientDTO? client)
        {
            Id= id;
            Name= name;
            Description= description;
            PriorityRating= priorityRating;
            DateAdded= dateAdded;
            CompleteBy= completedBy;
            Completed= completed;
            Worker = worker;
            Client = client;
        }
    }
}
