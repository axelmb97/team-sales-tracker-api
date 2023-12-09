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
    public class UserRepository : IUserRepository<User, string>
    {
        private readonly TeamSaleTrackerData _data;
        public UserRepository(TeamSaleTrackerData data)
        {
            _data = data;
        }
        public async Task<User> Add(User entity)
        {
            await _data.Users.AddAsync(entity);
            return entity;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _data.Users.Include(u => u.Address)
                .FirstOrDefaultAsync(user => user.Email.Equals(email));
            return user;
        }

        public async Task Save()
        {
            await _data.SaveChangesAsync();
        }
    }
}
