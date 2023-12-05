using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Models
{
    [Table("ROLES")]
    public class Role
    {
        [Column("role_id")]
        public long RoleId { get; set; }
        [Column("name")]
        public string  Name { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
    }
}
