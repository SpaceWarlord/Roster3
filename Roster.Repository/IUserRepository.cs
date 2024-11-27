using Roster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Returns all users. 
        /// </summary>
        Task<IEnumerable<User>> GetAsync();

        /// <summary>
        /// Returns all users with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<User>> GetAsync(string search);

        /// <summary>
        /// Returns the user with the given id. 
        /// </summary>
        Task<User> GetAsync(int id);

        /// <summary>
        /// Adds a new user if the user does not exist, updates the 
        /// existing user otherwise.
        /// </summary>
        Task<User> UpsertAsync(User user);

        /// <summary>
        /// Deletes a user.
        /// </summary>
        Task DeleteAsync(int userId);
    }
}
