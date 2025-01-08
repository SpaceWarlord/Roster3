using Microsoft.EntityFrameworkCore;
using Roster.App.DTO;
using Roster.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.Services
{
    public class ClientService
    {
        private readonly RosterContext _db;
        public ClientService(RosterContext db)
        {
            _db = db;
        }

        
        public async Task<List<ClientDTO>> GetAll()
        {
            return await _db.Clients.Select(x => x.ToClientDTO()).ToListAsync();
        }

        /*
        public async Task<bool> Update(ClientDTO client)
        {
            var found = _db.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
            if (found is null) return false;

            found.FirstName = client.FirstName;
            _db.SaveChanges();
            return true;
        }
        */
    }
}
