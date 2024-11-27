using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Repository.Sql
{
    /// <summary>
    /// Contains methods for interacting with the app backend using 
    /// SQL via Entity Framework Core 6.0. 
    /// </summary>
    public class SqlRosterRepository : IRosterRepository
    {
        private readonly DbContextOptions<RosterContext> _dbOptions;

        public SqlRosterRepository(DbContextOptionsBuilder<RosterContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new RosterContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public IUserRepository Users => new SqlUserRepository(
            new RosterContext(_dbOptions));

        
        public IClientRepository Clients => new SqlClientRepository(
            new RosterContext(_dbOptions));
        
    }
}
