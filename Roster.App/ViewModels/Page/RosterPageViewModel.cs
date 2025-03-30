using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Page
{
    public partial class RosterPageViewModel:BaseViewModel
    {
        public ObservableCollection<ShiftViewModel> Shifts;

        public RosterPageViewModel()
        {
            Shifts = new ObservableCollection<ShiftViewModel>();
        }
    }
}
