using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.DTO
{
    public class ShiftTemplateDTO: BaseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public WorkerDTO Worker { get; set; }

        public ClientDTO Client { get; set; }
        public string StartTime { get; set; }

        public string EndTime { get; set; }
                              

        public ShiftTemplateDTO(string id, string name, WorkerDTO worker, ClientDTO client, string startTime, string endTime)
        {
            Id = id;
            Name = name;
            Worker = worker;
            Client = client;
            StartTime = startTime;
            EndTime = endTime;
        }        
    }
}
