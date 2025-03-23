using Microsoft.EntityFrameworkCore;
using Roster.App.DTO;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.Services
{
    public class UserService:BaseService
    {
        
        public UserService(RosterDBContext db)
        {
            _db = db;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            return await _db.Users.Select(c => new UserDTO(c.Id, c.Username)).ToListAsync();
        }

        public async Task<bool> Update(UserDTO user)
        {
            var found = await _db.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (found is null) return false;
            found.Username = user.Username;            
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(UserDTO user)
        {
            var found = await _db.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (found is null) return false;
            var u = new User()
            {
                Id = user.Id,
                Username = user.Username,
                
            };
            _db.Users.Add(u);

            //if more then 0 something was added to database
            //https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.savechangesasync?view=efcore-9.0
            return (await _db.SaveChangesAsync()) > 0;
        }
    }
}
