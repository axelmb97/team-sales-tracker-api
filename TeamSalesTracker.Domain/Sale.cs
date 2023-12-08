using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain
{
    public class Sale
    {
        public long SaleId { get; set; }
        //public long IntervalId { get; set; }
        public Interval Interval { get; set; }
        [Column("branch_id")]
        //public long BranchId { get; set; }
        public Branch Branch { get; set; }
        public Decimal Amount { get; set; }
        public string Remarks { get; set; }
        public DateOnly CreatedAt { get; set; }
        public virtual List<SaleDetail> Details { get; set; }
    }
}
