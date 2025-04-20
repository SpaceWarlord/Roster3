using Microsoft.EntityFrameworkCore;
using Roster.App.DTO;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (found is not null)
            {
                return false;
            }
            else
            {
                Debug.WriteLine("User doesnt yet exist");
                Debug.WriteLine("id is " + user.Id);
                Debug.WriteLine("name is " + user.Username);
                User u = new User()
                {
                    Id = user.Id,
                    Username = user.Username,

                };
                using (var db = new RosterDBContext())
                {
                    db.Users.Add(u);
                    Debug.WriteLine("Added the user");
                    //if more then 0 something was added to database
                    //https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.savechangesasync?view=efcore-9.0
                    try
                    {

                        return (await db.SaveChangesAsync()) > 0;
                    }
                    catch (DbUpdateException ex)
                    {
                        Debug.WriteLine($"Unique constraint {ex.ToString()} violated. Duplicate value for {ex.InnerException.ToString()}");

                        var failedEntries = ex.Entries;
                        foreach (var entry in failedEntries)
                        {
                            var entityName = entry.Metadata.Name;
                            var properties = entry.Properties.Where(p => p.IsModified && !p.IsTemporary);
                            foreach (var property in properties)
                            {
                                var propertyName = property.Metadata.Name;
                                Debug.WriteLine($"Failed to update field: {propertyName} in entity: {entityName}");
                            }
                        }
                        return false;
                    }
                }                    
            }                
        }
    }
}
