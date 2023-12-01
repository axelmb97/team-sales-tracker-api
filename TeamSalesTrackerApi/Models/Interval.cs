using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Models
{
    [Table("INTERVALS")]
    public class Interval
    {
        [Column("interval_id")]
        public long IntervalId { get; set; }
        [Column("from")]
        public DateOnly From { get; set; }
        [Column("until")]
        public DateOnly Until { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Column("target_amount")]
        public Decimal TargetAmount { get; set; }
        [Column("created_at")]
        public DateOnly CreatedAt { get; set; }
        [Column("state")]
        public IntervalState State { get; set; }
        public List<IntervalTarget> Targets { get; set; }

    }
}
