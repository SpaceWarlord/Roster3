using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Data
{
    public class SuburbViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }

        public SuburbViewModel(string name, string postCode)
        {
            Name = name;
            PostCode = postCode;
        }
    }
}
