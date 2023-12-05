using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Models
{
    [Table("USERS_ROLES")]
    public class UserRole
    {
    
        [Column("user_role_id")]
        public long UserRoleId { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Column("role_id")]
        public long RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
