using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain
{
    public class Interval
    {
        public long IntervalId { get; set; }
        public DateOnly From { get; set; }
        public DateOnly Until { get; set; }
        //public long UserId { get; set; }
        public User User { get; set; }
        public Decimal TargetAmount { get; set; }
        public DateOnly CreatedAt { get; set; }
        public IntervalState State { get; set; }
        public virtual List<IntervalTarget> Targets { get; set; }
    }
}
