﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class Suburb:BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }

        public Suburb(string name, string postCode)
        {
            Name = name;
            PostCode = postCode;
        }
    }
}
