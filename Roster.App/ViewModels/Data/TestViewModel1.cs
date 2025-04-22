using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Data
{
    public partial class TestViewModel1 : DataViewModel
    {
        public override T ToDTO<T>()
        {
            throw new NotImplementedException();
        }

        public override T ToModel<T>()
        {
            throw new NotImplementedException();
        }
    }
}
