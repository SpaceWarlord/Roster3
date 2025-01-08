using Roster.App.DTO;
using Roster.App.ViewModels;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.Helpers
{
    public static class Extensions
    {
        public static List<ClientDTO> ToClientDTO(this List<Client> source)
        {
            return [.. source.Select(x => new ClientDTO
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Nickname = x.Nickname,
            Gender = x.Gender,
        })];
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