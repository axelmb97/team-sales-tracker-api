using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Services.Implementations
{
    public class EncryptService : IEncryptService
    {
       
        public EncryptData Encrypt(string password)
        {
            EncryptData data = new EncryptData();
            data.PasswordSalt = GenerateRandomSalt();

            using (var hmac = new HMACSHA512(data.PasswordSalt))
            {
                var encryptPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                data.Password = ByteToString(encryptPass);
                return data;
            }
        }

        public bool VerifyPassword(string password, byte[] passSalt, string actualPass)
        {
            using (var hmac = new HMACSHA512(passSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                var enteredPassword = ByteToString(computedHash);
                return enteredPassword.Equals(actualPass);
            }
        }

        private byte[] GenerateRandomSalt()
        {
            
            var salt = new byte[64]; 
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private string ByteToString(byte[] pass)
        {
            StringBuilder result = new StringBuilder(pass.Length * 2);
            foreach (byte b in pass)
            {
                result.AppendFormat("{0:x2}", b);
            }
            return result.ToString();
        }
    }
}
