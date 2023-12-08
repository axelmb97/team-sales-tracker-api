using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain
{
    public class Branch
    {
        public long BranchId { get; set; }
        public string Name { get; set; }
        public long BranchNumber { get; set; }
        //public long AddressId { get; set; }
        public virtual Address Address { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
