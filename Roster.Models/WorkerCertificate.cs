using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public partial class WorkerCertificate
    {        
        public Worker Worker;
        
        public Certificate _certificate {  get; set; }
        
        public DateOnly _dateObtained {  get; set; }
        
    }
}