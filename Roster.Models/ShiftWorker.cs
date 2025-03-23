using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{

    [Table("ShiftWorker", Schema = "TPT")]
    public class ShiftWorker
    {
        [Key]
        public int Id { get; set; }
        public int ShiftId { get; set; }        
        public Shift Shift { get; set; }
        public int WorkerId {  get; set; }
        
        public Worker Worker;
            
        public DateOnly StartDateTime;
        
        public DateOnly EndDateTime;

#nullable enable

        public ShiftAddress? StartLocation;

        public ShiftAddress? EndLocation;

#nullable disable
        public List<Route> Routes { get; set; }

        public ShiftWorker() { }

        public ShiftWorker(Shift shift, Worker worker, DateOnly startDateTime, DateOnly endDateTime)
        {
            Shift = shift;
            Worker = worker;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

    }
}