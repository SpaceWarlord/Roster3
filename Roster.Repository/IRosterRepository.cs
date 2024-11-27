using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Roster.Models;

namespace Roster.Repository
{
    /// <summary>
    /// Defines methods for interacting with the app backend.
    /// </summary>
    public interface IRosterRepository
    {
        /// <summary>
        /// Returns the users repository.
        /// </summary>
        IUserRepository Users { get; }

        /// <summary>
        /// Returns the customers repository.
        /// </summary>
        IClientRepository Clients { get; }


        /*
        /// <summary>
        /// Returns the orders repository.
        /// </summary>
        IOrderRepository Orders { get; }

        /// <summary>
        /// Returns the products repository.
        /// </summary>
        IProductRepository Products { get; }

        */
    }
}
