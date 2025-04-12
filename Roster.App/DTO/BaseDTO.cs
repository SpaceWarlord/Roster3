using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.DTO
{
    public abstract class BaseDTO
    {
        /*
        public static BaseDTO ToDTO<T>() where T : BaseDTO
        {
            return 
        } 
        */

        /*
        public abstract T ToDTO<T>() where T : BaseDTO;        
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
