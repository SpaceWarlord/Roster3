using Microsoft.EntityFrameworkCore;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Repository.Sql
{
    /// <summary>
    /// Entity Framework Core DbContext for Roster.
    /// </summary>
    public class RosterContext : DbContext
    {
        /// <summary>
        /// Creates a new Roster DbContext.
        /// </summary>
        public RosterContext(DbContextOptions<RosterContext> options) : base(options)
        { }

        /// <summary>
        /// Gets the users DbSet.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets the clients DbSet.
        /// </summary>
        public DbSet<Client> Clients { get; set; }        
    }
}
