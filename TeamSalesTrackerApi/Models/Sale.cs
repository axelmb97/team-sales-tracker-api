using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Models
{
    [Table("SALES")]
    public class Sale
    {
        [Column("sale_id")]
        public long SaleId { get; set; }
        [Column("interval_id")]
        public long IntervalId { get; set; }
        [ForeignKey("IntervalId")]
        public Interval Interval { get; set; }
        [Column("branch_id")]
        public long BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        [Column("amount")]
        public Decimal Amount { get; set; }
        [Column("remarks")]
        public string Remarks { get; set; }
        [Column("created_at")]
        public DateOnly CreatedAt { get; set; }

        public virtual List<SaleDetail> Details { get; set; }
    }
}
