using System.Security.Cryptography.Xml;
using TeamSalesTrackerApi.Dtos;

namespace TeamSalesTrackerApi.Services.Interfaces
{
    public interface IEncryptService
    {
        EncryptData Encrypt(string password);
        bool VerifyPassword(string password,byte[] passSalt, string actualPass);

    }
}
