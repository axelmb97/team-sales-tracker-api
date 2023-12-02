using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Models
{
    [Table("SALE_DETAILS")]
    public class SaleDetail
    {
        [Column("sale_detail_id")]
        public long SaleDetailId { get; set; }
        [Column("product_id")]
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("remarks")]
        public string Remarks { get; set; }
        [Column("sale_id")]
        public long SaleId { get; set; }
        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }
    }
}
