using Roster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.DTO
{
    public class TestDTO:BaseDTO
    {
        public string Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public TestDTO(string id, string? name, string description, DateTimeOffset startDate, DateTimeOffset endDate, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
