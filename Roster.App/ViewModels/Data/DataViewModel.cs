using Roster.App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Data
{
    public abstract class DataViewModel : BaseViewModel
    {
        public abstract T ToDTO<T>() where T : BaseDTO;        
    }
}
