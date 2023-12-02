using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Auth;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IEncryptService _encryptService;
        private readonly ITokenService _tokenService;
        private readonly SalesTrackerDB _data;
        private readonly IMapper _mapper;

        public AuthService(IEncryptService encryptService, ITokenService tokenService, SalesTrackerDB data, IMapper mapper)
        {
            _encryptService = encryptService;
            _tokenService = tokenService;
            _data = data;
            _mapper = mapper;
        }

        public async Task<RegisterResult> RegisterUser(RegisterUserCommand userData)
        {
            var result = new RegisterResult();
            var existingEmail = await _data.Users.FirstOrDefaultAsync(user => user.Email.Equals(userData.Email));
            if (existingEmail != null) {
                result.SetError("El email ya se encuentra registrado. Pruebe con otro.", System.Net.HttpStatusCode.BadRequest);
                return result;
            }

            var address = _mapper.Map<Address>(userData);
            _data.Addresses.Add(address);
            await _data.SaveChangesAsync();


            var user = _mapper.Map<User>(userData);
            user.Password = _encryptService.Encrypt(userData.Password);
            user.AddressId = address.AddressId;
            user.Address = address;
            _data.Users.Add(user);
            await _data.SaveChangesAsync();

            result.user = _mapper.Map<RegisteredUserDto>(user);
            result.Token = _tokenService.CreateToken(user);
            result.Message = "Usuario registrado con éxito";
            return result;
        }

        public async Task<string> VerifyCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
