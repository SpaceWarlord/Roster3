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
    public class AddressService:BaseService
    {
        private readonly RosterDBContext _db;
        public AddressService(RosterDBContext db)
        {
            _db = db;
        }

        public async Task<List<AddressDTO>> GetAll()
        {
            return await _db.Addresses.Select(c => new AddressDTO(c.Id, c.Name, c.UnitNum, c.StreetNum, c.StreetName, c.StreetType, c.Suburb, c.City)).ToListAsync();
        }

        public async Task<bool> AddUpdate(AddressDTO address)
        {
            Debug.WriteLine("-- AddUpdate --");
            Debug.WriteLine(address.ToString());
            var found = await _db.Addresses.FirstOrDefaultAsync(x => x.Id == address.Id);
            if (found is null) // new address
            {
                Debug.WriteLine("New address");
                var nameExists = await _db.Addresses.FirstOrDefaultAsync(x => x.Name == address.Name);
                if (nameExists is null)
                {
                    Debug.WriteLine("Adding new address");
                    var a = new Address()
                    {

                        Id = address.Id,
                        Name = address.Name,
                        UnitNum = address.UnitNum,
                        StreetNum = address.StreetNum,
                        StreetName = address.StreetName,
                        StreetType = address.StreetType,
                        Suburb = address.Suburb,
                        City = address.City,
                       
                    };
                    _db.Addresses.Add(a);
                    return (await _db.SaveChangesAsync()) > 0;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Debug.WriteLine("Existing address");
                var nameExists = await _db.Addresses.FirstOrDefaultAsync(x => x.Name == address.Name && x.Id != address.Id);
                if (nameExists is null)
                {
                    Debug.WriteLine("Updating existing address");
                    found.Name = address.Name;
                    found.UnitNum = address.UnitNum;
                    found.StreetNum = address.StreetNum;
                    found.StreetName = address.StreetName;
                    found.StreetType = address.StreetType;
                    found.Suburb = address.Suburb;
                    found.City = address.City;
                    return (await _db.SaveChangesAsync()) > 0;
                }
                else
                {
                    return false;
                }
            }
        }        
    }
}
