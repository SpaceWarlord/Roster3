﻿using Roster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Repository
{
    /// <summary>
    /// Defines methods for interacting with the customers backend.
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Returns all customers. 
        /// </summary>
        Task<IEnumerable<Client>> GetAsync();

        /// <summary>
        /// Returns all customers with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<Client>> GetAsync(string search);

        /// <summary>
        /// Returns the customer with the given id. 
        /// </summary>
        Task<Client> GetAsync(int id);

        /// <summary>
        /// Adds a new customer if the customer does not exist, updates the 
        /// existing customer otherwise.
        /// </summary>
        Task<Client> UpsertAsync(Client client);

        /// <summary>
        /// Deletes a customer.
        /// </summary>
        Task DeleteAsync(int clientId);
    }
}
