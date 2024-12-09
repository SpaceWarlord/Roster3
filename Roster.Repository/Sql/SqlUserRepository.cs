using Microsoft.EntityFrameworkCore;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Repository.Sql
{
    /// <summary>
    /// Contains methods for interacting with the users backend using 
    /// SQL via Entity Framework Core 2.0.
    /// </summary>
    public class SqlUserRepository : IUserRepository
    {
        private readonly RosterContext _db;

        public SqlUserRepository(RosterContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            Debug.WriteLine("in get async");
            return await _db.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {            
            return await _db.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<IEnumerable<User>> GetAsync(string value)
        {
            string[] parameters = value.Split(' ');
            return await _db.Users
                .Where(user =>
                    parameters.Any(parameter =>
                        user.Username.StartsWith(parameter)))
                .OrderByDescending(user =>
                    parameters.Count(parameter =>
                        user.Username.StartsWith(parameter)))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> UpsertAsync(User user)
        {
            var current = await _db.Users.FirstOrDefaultAsync(_user => _user.Id == user.Id);
            if (null == current)
            {
                _db.Users.Add(user);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(user);
            }
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(_user => _user.Id == id);
            if (user != null)
            {
                /*
                var orders = await _db.Orders.Where(order => order.UserId == id).ToListAsync();
                _db.Orders.RemoveRange(orders);
                */
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }
    }
}