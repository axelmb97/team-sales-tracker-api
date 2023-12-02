using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Services.Implementations
{
    public class EncryptService : IEncryptService
    {
        private readonly IConfiguration _configuration;
        public EncryptService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public byte[] Encrypt(string password)
        {
            using (var hmac = new HMACSHA512()) {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            }
        }

        public bool VerifyPassword(string password, byte[] actualPass)
        {
            var passSalt = Encoding.UTF8.GetBytes(_configuration["JWT:key"]);
            using (var hmac = new HMACSHA512(passSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(actualPass);
            }
        }
    }
}
