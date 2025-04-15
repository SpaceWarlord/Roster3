using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class Test
    {
        public string Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }

        public Test()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Test(string id)
        {
            Id = id;
        }
    }
}
