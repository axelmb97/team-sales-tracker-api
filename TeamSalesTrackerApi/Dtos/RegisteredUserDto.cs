using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Dtos
{
    public class RegisteredUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
