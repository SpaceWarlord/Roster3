using Roster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace Roster.App.DTO
{
    public class UserDTO: BaseDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public UserDTO(string id, string username)
        {
            Id = id;
            Username = username;            
        }
    }
}
