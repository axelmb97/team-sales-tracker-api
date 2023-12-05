using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Models
{
    [Table("USERS")]
    public class User
    {
        [Column("user_id")]
        public long UserId { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("password_salt")]
        public byte[] PasswordSalt { get; set; }
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        [Column("address_id")]
        public long AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
        public virtual List<Interval> Intervals { get; set; }

        public virtual List<UserRole> Roles { get; set; }
    }
}
