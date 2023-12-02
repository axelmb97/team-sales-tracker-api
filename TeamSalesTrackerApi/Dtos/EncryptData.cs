namespace TeamSalesTrackerApi.Dtos
{
    public class EncryptData
    {
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
