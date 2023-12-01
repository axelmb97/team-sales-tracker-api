using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Models
{
    [Table("INTERVAl_TARGETS")]
    public class IntervalTarget
    {
        [Column("interval_target_id")]
        public long IntervalTargetId { get; set; }
        [Column("product_id")]
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("remarks")]
        public string Remarks { get; set; }
        [Column("interval_id")]
        public long IntervalId { get; set; }
        [ForeignKey("IntervalId")]
        public Interval Interval { get; set; }
    }
}
