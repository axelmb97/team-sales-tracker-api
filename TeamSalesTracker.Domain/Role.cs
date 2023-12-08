using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain
{
    public class Role
    {
        public long RoleId { get; set; }
        public string Name { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
    }
}
