using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSalesTracker.Application.Interfaces;
using TeamSalesTracker.Domain;
using TeamSalesTracker.Domain.Interfaces;

namespace TeamSalesTracker.Application.Implementations
{
    public class UserService : IUserService<User, string>
    {
        private readonly IUserRepository<User, string> _userRepository;
        private readonly IAddressRepository<Address, long> _addressRepository;
        public UserService(IUserRepository<User, string> userRepository, IAddressRepository<Address, long> addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public async Task<User> Add(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException("El usuario es requerido");
            await _addressRepository.Add(entity.Address);
          
            var user = await _userRepository.Add(entity);
            await _userRepository.Save();
            return user;

        }

        public async Task<User> GetByEmail(string entityEmail)
        {
            return await _userRepository.GetByEmail(entityEmail);
        }
    }
}
