using Microsoft.EntityFrameworkCore;
using Roster.App.DTO;
using Roster.Models;
using Roster.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roster.App.Helpers;

namespace Roster.App.Services
{
    public class ClientService
    {
        private readonly RosterDBContext _db;
        public ClientService(RosterDBContext db)
        {
            _db = db;
        }

        public async Task<List<ClientDTO>> GetAll()
        {
            return await _db.Clients.Select(c => new ClientDTO(c.Id, c.FirstName, c.LastName, c.Nickname, c.Gender)).ToListAsync();
        }

        public async Task<bool> Update(ClientDTO client)
        {
            var found = await _db.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
            if (found is null) return false;
            found.FirstName = client.FirstName;
            found.LastName = client.LastName;
            found.Gender = client.Gender;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(ClientDTO client)
        {
            var found = await _db.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
            if (found is null) return false;            
            var c = new Client()
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Nickname = client.Nickname,
                Gender = client.Gender,
            };
            _db.Clients.Add(c);

            //if more then 0 something was added to database
            //https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.savechangesasync?view=efcore-9.0
            return (await _db.SaveChangesAsync()) > 0;
        }
    }
}