using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSalesTracker.Domain;
using TeamSalesTracker.Domain.Interfaces;
using TeamSalesTracker.Infraestructure.Data.Contexts;

namespace TeamSalesTracker.Infraestructure.Data.Repositories
{
    public class AddressRepository : IAddressRepository<Address, long>
    {
        private readonly TeamSaleTrackerData _data;
        public AddressRepository(TeamSaleTrackerData data)
        {
            _data = data;
        }

        public async Task<Address> Add(Address entity)
        {
            await _data.Addresses.AddAsync(entity);
            return entity;
        }

        public async Task<Address> Delete(long entityId)
        {
            var address = await _data.Addresses.FirstOrDefaultAsync(a => a.AddressId.Equals(entityId));
            if (address != null) {
                _data.Addresses.Remove(address);
            }
            
            return address;
        }

        public async Task<Address> Edit(Address entity)
        {
            var address = await _data.Addresses.FirstOrDefaultAsync(a => a.AddressId.Equals(entity.AddressId));
            if (address != null) { 
                address.StreetName = entity.StreetName;
                address.StreetNumber = entity.StreetNumber;
                address.ZipCode = entity.ZipCode;
                address.Apartment = entity.Apartment;
                _data.Entry(address).State = EntityState.Modified;
            }
            _data.Addresses.Update(address);
            return entity;
        }

        public async Task<Address> GetById(long entityId)
        {
            var address = await _data.Addresses.FirstOrDefaultAsync(a => a.AddressId.Equals(entityId));
            return address;
        }

        public async Task Save()
        {
            await _data.SaveChangesAsync();
        }
    }
}
