using TeamSalesTrackerApi.Dtos;

namespace TeamSalesTrackerApi.Results.Auth
{
    public class RegisterResult : BaseResult
    {
        public RegisteredUserDto user { get; set; }
        public string  Token { get; set; }
    }
}
