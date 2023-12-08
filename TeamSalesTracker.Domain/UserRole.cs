using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain
{
    public class UserRole
    {
        public long UserRoleId { get; set; }
        //public long UserId { get; set; }
        public User User { get; set; }
        //public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}
