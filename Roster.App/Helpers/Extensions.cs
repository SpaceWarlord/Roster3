using Roster.App.DTO;
using Roster.App.ViewModels;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.Helpers
{
    public static class Extensions
    {
        public static List<ClientDTO> ToClientDTO(this List<Client> source)
        {
            return [.. source.Select(x => new ClientDTO(x.Id, x.FirstName, x.LastName, x.Nickname, x.Gender))];
        }        

        public static Client ToClient(this Client dto)
        {

            var client = new Client()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Nickname = dto.Nickname,
                Gender = dto.Gender,
            };
            return client;
        }

        /*
        public static List<ClientViewModel> ToClientViewModel(this List<ClientDTO> source)
        {
            return [.. source.Select(x => new ClientViewModel
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Nickname = x.Nickname,
            Gender = x.Gender,
            Dob = x.DOB,
            Email = x.Email,
            Phone = x.Phone,
            HighlightColor = x.HighlightColor,
            Address = x.Address,

        })];
        }
        */
    }
}