using MediatR;
using TeamSalesTrackerApi.Results.Auth;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class RegisterUserCommand : IRequest<RegisterResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string Apartment { get; set; }
        public List<long> RolesId { get; set; }

    }
}
