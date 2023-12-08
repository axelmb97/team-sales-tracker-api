using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain
{
    public class IntervalTarget
    {
        public long IntervalTargetId { get; set; }
        //public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
        //public long IntervalId { get; set; }
        public Interval Interval { get; set; }
    }
}
