using System.Security.Cryptography.Xml;

namespace TeamSalesTrackerApi.Services.Interfaces
{
    public interface IEncryptService
    {
        byte[] Encrypt(string password);
        bool VerifyPassword(string password, byte[] actualPass);

    }
}
