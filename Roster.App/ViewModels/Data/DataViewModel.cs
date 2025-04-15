using Roster.App.DTO;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Roster.App.ViewModels.Data
{
    public abstract class DataViewModel : BaseViewModel
    {
        public abstract T ToDTO<T>() where T : BaseDTO;

        public abstract T ToModel<T>() where T : BaseDTO;
        /*
        public static T DTOToModel<T>(T dto) where T: BaseDTO 
        {
            return (T)Convert.ChangeType(dto, typeof(T));
        }
        */
        

        public override string ToString()
        {
            return GetType().GetProperties()
        .Select(info => (info.Name, Value: info.GetValue(this, null) ?? "(null)"))
        .Aggregate(
            new StringBuilder(),
            (sb, pair) => sb.AppendLine($"{pair.Name}: {pair.Value}"),
            sb => sb.ToString());
        }
    }
}
